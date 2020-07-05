import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var google: any;

const URL = "https://localhost:44377/api/Orders/"

@Component({
  selector: 'app-orders-De3',
  templateUrl: './ordersDe3.component.html'
})
export class OrdersComponentDe3 {

  DSDonHangTrongKhoangThoiGianTheoTenNhanVien:[];

  DSDoanhThuQuocGia:[];


  tenNV:any;
  datef:Date
  datel:Date
  page:any;
  totalPage:any;
  month:any;
  year:any;
  

  loadSuccess:boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }


  layDanhSachDonHangTheoTenNhanVien(tenNhanVien,datef,datel,page){
    var x = 
      {
        "tenNhanVien": tenNhanVien,
        "dateBegin": datef,
        "dateEnd": datel,
        "page": page,
        "size": 5
      }
      this.http.post(URL + "danh-sach-don-hang-theo-ten-nhan-vien-LINQ",x).subscribe(
        (res:any) =>{
          if(res.data.data.length > 0){  
            this.page = res.data.page; 
            this.totalPage = res.data.totalPage;       
            this.DSDonHangTrongKhoangThoiGianTheoTenNhanVien = res.data.data;
          }else{
            alert("Không tìm thấy")
          }
         
        },err=>{console.log(err)}
      )    
    
  }

  layDoanhThuTheoQuocGia(month,year){
    var x = {
      "month": month,
      "year": year
    }

    this.http.post(URL + "danh-thu-theo-quoc-gia-LINQ",x).subscribe(
      (res:any) =>{
        if(res.data.length > 0){      
          this.DSDoanhThuQuocGia = res.data;
          this.drawChart(res.data);
        }else{
          alert("Không tìm thấy")
        }
       
      },err=>{console.log(err)}
    )    
  }

  trangTiep(){
    if(this.page < this.totalPage){
      this.layDanhSachDonHangTheoTenNhanVien(this.tenNV,this.datef,this.datel,this.page+1);
    }else{
      alert("You are in the last page")
    }
  }

  trangTruoc(){
    if(this.page > 1){
      this.layDanhSachDonHangTheoTenNhanVien(this.tenNV,this.datef,this.datel,this.page-1);
    }else{
      alert("You are in the first page")
    }
    
  }


  drawChart(charData) {

    var arrData = [['Quốc Gia','Doanh Thu']];

    charData.forEach(element => {
      var item = [];
      
      item.push(element.shipCountry);
      item.push(element.doanhThu);
      arrData.push(item);
    });
    var data = google.visualization.arrayToDataTable(arrData);

    var options = {
      title: 'Doanh Thu Quốc Gia'
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

    chart.draw(data, options);

  }


}

