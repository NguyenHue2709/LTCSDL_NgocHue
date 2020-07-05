import { DeSo4Component } from './../de-so-4/de-so-4.component';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var google: any;

const URL = "https://localhost:44377/api/Products/"

@Component({
  selector: 'app-de-so-5',
  templateUrl: './de-so-5.component.html'
})
export class DeSo5Component {

  datef:Date
  datel:Date


  dsSoLuongHangHoa:[];
  loadSuccess:boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }

  //Câu 5 đề 5
  soLuongHangHoaCanGiao(datef,datel){
    var x ={
      "dateBegin": datef,
      "dateEnd": datel
    }
    this.http.post(URL + "so-luong-hang-hoa-can-giao-trong-ngay",x).subscribe(
      (res:any) =>{
        if(res.data.length > 0){  
          this.dsSoLuongHangHoa = res.data;
          this.loadSuccess = true;
          this.drawChart(res.data);
        }else{
          alert("Không tìm thấy")
        }
      },err=>{console.log(err)}
    )
  }


  drawChart(charData) {

    var arrData = [['Ngày','Số lượng cần giao']];

    charData.forEach(element => {
      var item = [];
      var date = new Date(element.requiredDate)
      var s = "Ngay " + date.getDate() + " Thang " + (date.getMonth() + 1)     
      item.push(s);
      item.push(element.soLuongHangHoa);
      arrData.push(item);
    });
    var data = google.visualization.arrayToDataTable(arrData);

    var options = {
      title: 'Số lượng hàng hóa cần giao trong ngày'
    };

    var chart = new google.charts.Bar(document.getElementById('barchart_material'));

    chart.draw(data, options);

  }
  
}

