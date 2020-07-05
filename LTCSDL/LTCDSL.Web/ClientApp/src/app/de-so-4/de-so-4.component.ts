import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var google: any;

const URL = "https://localhost:44377/api/Categories/"

@Component({
  selector: 'app-de-so-4',
  templateUrl: './de-so-4.component.html'
})
export class DeSo4Component {

  month:any = 7;
  year:any = 1996;


  dsShippers:[];
  loadSuccess:boolean = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }

  //Câu 5 đề 4
  doanhThuShippers(thang,nam){
    var x ={
      "thang": thang,
      "nam": nam
    }
    this.http.post(URL + "danh-sach-shipper-LINQ",x).subscribe(
      (res:any) =>{
        if(res.data.length > 0){     
          this.dsShippers = res.data;
          this.loadSuccess = true;
          this.drawChart(res.data);
        }else{
          alert("Không tìm thấy")
        }
      },err=>{console.log(err)}
    )
  }


  drawChart(charData) {

    var arrData = [['ShipperID','Doanh Thu']];

    charData.forEach(element => {
      var item = [];
      
      item.push(element.companyName);
      item.push(element.tien);
      arrData.push(item);
    });
    var data = google.visualization.arrayToDataTable(arrData);

    var options = {
      title: 'Doanh Thu Shippers'
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart'));

    chart.draw(data, options);

  }
  
}

