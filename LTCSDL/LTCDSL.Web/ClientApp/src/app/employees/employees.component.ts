import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

const URL = "https://localhost:44377/api/Employees/"

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {

  date:Date = new Date("1997-07-04T00:00:00");

  datef:Date = new Date("1997-07-04T00:00:00");
  datel:Date = new Date("1997-07-10T00:00:00");


  DSDoanhThuNhanVien:[]
  DSDoanhThuTrongKhoangThoiGian:[]
  loadSuccess:boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.layDanhSachNhanVien(this.date);
    this.doanhThuTrongKhoangThoiGian(this.datef,this.datel);
  }

  //Câu 4 đề 1
  layDanhSachNhanVien(ngay){
    var x ={
      "date":ngay
    }
    this.http.post(URL + "doanh-thu-nhan-vien",x).subscribe(
      (res:any) =>{
        if(res.data.length > 0){     
          
          this.DSDoanhThuNhanVien = res.data;
          this.loadSuccess = true;
        }else{
          alert("Không tìm thấy")
        }
      },err=>{console.log(err)}
    )
  }
  //Câu 4 đề 1
  doanhThuTrongKhoangThoiGian(date1,date2){
    var x = {
      "dateBegin": date1,
      "dateEnd": date2
    }
    this.http.post(URL + "doanh-thu-nhan-vien-trong-thoi-gian",x).subscribe(
      (res:any) =>{
        if(res.data.length > 0){     
          this.DSDoanhThuTrongKhoangThoiGian = res.data;
          this.loadSuccess = true;
        }else{
          alert("Không tìm thấy")
        }
      },err=>{console.log(err)}
    )
  }
}

