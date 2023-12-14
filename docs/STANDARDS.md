<div style="text-align:center; margin-bottom: 50px">
  <h1>KODLAMA STANDARTLARI</h1>
</div>
<table>
  <thead style="align:center">
    <tr>
      <th style="text-align:center; width:50%;">
        <strong>Kelime</strong>
      </th>
      <th style="text-align:center; width:100%;">
        <strong>Açıklama</strong>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td style="text-align:center">Swagger / Redoc</td>
      <td style="text-align:center"> Summary , remarks , response codes ve returns alanlarından oluşmalıdır. </td>
    </tr>
    <tr>
      <td style="text-align:center">Validasyon</td>
      <td style="text-align:center"> Validasyonlar yazýlýrken alt alta yazılacaktır. VehicleGetByDetailIdQueryValidator sınıfını örnek alabiliriz. </td>
    </tr>
    <tr>
      <td style="text-align:center">Test</td>
      <td style="text-align:center"> Servisler test edilirken muhakkak postman'e eklenmeli ve kontrol edilmelidir. </td>
    </tr>
    <tr>
      <td style="text-align:center">PR Gönderimi</td>
      <td style="text-align:center"> Clean + Rebuild yapılır.Uygulama ayağa kaldırılıp swagger ve postman üzerinden test yapılır. Değişiklik yapılan kodların senaryo ve verileri kontrol edilir. </td>
    </tr>
  </tbody>
</table>
<div style="text-align:center; margin-bottom: 50px">
  <h1>NUGET STANDARTLARI</h1>
</div>
<table>
  <thead style="align:center">
    <tr>
      <th style="text-align:center; width:50%;">
        <strong>Kelime</strong>
      </th>
      <th style="text-align:center; width:100%;">
        <strong>Açıklama</strong>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td style="text-align:center">EntityFramework (Hepsi)</td>
      <td style="text-align:center">6.0.12</td>
    </tr>
    <tr>
      <td style="text-align:center">MediatR (Hepsi)</td>
      <td style="text-align:center">11.1.0</td>
    </tr>
    <tr>
      <td style="text-align:center">AutoMapper</td>
      <td style="text-align:center">12.0.1</td>
    </tr>
  </tbody>
</table>
<div style="text-align:center; margin-bottom: 50px">
  <h1>KLASÖR STANDARTLARI</h1>
</div>
<table>
  <thead style="align:center">
    <tr>
      <th style="text-align:center; width:50%;">
        <strong>Kelime</strong>
      </th>
      <th style="text-align:center; width:100%;">
        <strong>Açıklama</strong>
      </th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td style="text-align:center">Application</td>
      <td style="text-align:center">CQRS sınıflarının bulunduğu yerdir</td>
    </tr>
  </tbody>
</table>