import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const URL = "https://localhost:44377/api/Orders/"
const SIZE = 5;

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent {

  DSDonHangTrongKhoangThoiGian:[];

  chiTietDonHang:[];
  datef:Date = new Date("1997-07-04T00:00:00");
  datel:Date = new Date("1997-07-10T00:00:00");
  madon:any;



  loadSuccess:boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.layDanhSachDonHangTrongKhoanThoiGian(this.datef,this.datel);
  }

  layDanhSachDonHangTrongKhoanThoiGian(date1,date2){
    var x = {
      "dateBegin": date1,
      "dateEnd": date2
    }
    this.http.post(URL + "danh-sach-don-hang-trong-khoan-thoi-gian",x).subscribe(
      (res:any) =>{
        if(res.data.length > 0){          
          this.DSDonHangTrongKhoangThoiGian = res.data;
          this.loadSuccess = true;
        }else{
          alert("Khong Tìm thấy")

        }
        
      },err=>{console.log(err)}
    )
  }

  layChiTietDonHang(maDonHang){
    var x = {
      "maDonHang":maDonHang
    }
    this.http.post(URL + "chi-tiet-don-hang",x).subscribe(
      (res:any) =>{
        if(res.data.length > 0){          
          this.chiTietDonHang = res.data;
        }else{
          alert("Không tìm thấy")
        }
       
      },err=>{console.log(err)}
    )
  }



}

