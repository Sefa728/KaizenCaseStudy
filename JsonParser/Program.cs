using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ReceiptItem
{
    public string Description { get; set; }
    public Coordinates Coordinates { get; set; }
}

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Receipt
{
    public List<ReceiptItem> Items { get; set; }
}

public class Program
{
    public static void Main()
    {
        string jsonResponse = @"{
            ""items"": [
                {""description"": ""TEŞEKKÜRLER"", ""coordinates"": {""x"": 10, ""y"": 10}},
                {""description"": ""GUNEYDOĞU TEKS. GIDA INS SAN. LTD.STI."", ""coordinates"": {""x"": 10, ""y"": 20}},
                {""description"": ""ORNEKTEPE MAH.ETIBANK CAD.SARAY APT."", ""coordinates"": {""x"": 10, ""y"": 30}},
                {""description"": ""N:43-1 BEYOĞLU/ISTANBUL"", ""coordinates"": {""x"": 10, ""y"": 40}},
                {""description"": ""GÜNEŞLİ V.D. 4350078928 V. NO."", ""coordinates"": {""x"": 10, ""y"": 50}},
                {""description"": ""TARIH : 26.08.2020"", ""coordinates"": {""x"": 10, ""y"": 60}},
                {""description"": ""SAAT : 15:27"", ""coordinates"": {""x"": 10, ""y"": 70}},
                {""description"": ""FİŞ NO : 0082"", ""coordinates"": {""x"": 10, ""y"": 80}},
                {""description"": ""54491250"", ""coordinates"": {""x"": 10, ""y"": 90}},
                {""description"": ""2 ADx 2,75"", ""coordinates"": {""x"": 10, ""y"": 100}},
                {""description"": ""CC.COCA COLA CAM 200 08 *5,50"", ""coordinates"": {""x"": 10, ""y"": 110}},
                {""description"": ""2701084"", ""coordinates"": {""x"": 10, ""y"": 120}},
                {""description"": ""1,566 KGx 1,99"", ""coordinates"": {""x"": 10, ""y"": 130}},
                {""description"": ""MANAV DOMATES PETEME *3,32"", ""coordinates"": {""x"": 10, ""y"": 140}},
                {""description"": ""2701076"", ""coordinates"": {""x"": 10, ""y"": 150}},
                {""description"": ""0,358 KGx 4,99"", ""coordinates"": {""x"": 10, ""y"": 160}},
                {""description"": ""MANAV BIBER CARLISTO 08 *1,79"", ""coordinates"": {""x"": 10, ""y"": 170}},
                {""description"": ""4"", ""coordinates"": {""x"": 10, ""y"": 180}},
                {""description"": ""EKMEK CIFTLI 01 *1,25"", ""coordinates"": {""x"": 10, ""y"": 190}},
                {""description"": ""TOPKDV *0,80"", ""coordinates"": {""x"": 10, ""y"": 200}},
                {""description"": ""TOPLAM *11,86"", ""coordinates"": {""x"": 10, ""y"": 210}},
                {""description"": ""NAKİT *20,00"", ""coordinates"": {""x"": 10, ""y"": 220}},
                {""description"": ""KDV KDV TUTARI KDV'LI TOPLAM"", ""coordinates"": {""x"": 10, ""y"": 230}},
                {""description"": ""01 *0,01 *1,25"", ""coordinates"": {""x"": 10, ""y"": 240}},
                {""description"": ""08 *0,79 *10,61"", ""coordinates"": {""x"": 10, ""y"": 250}},
                {""description"": ""KASİYER : SUPERVISOR"", ""coordinates"": {""x"": 10, ""y"": 260}},
                {""description"": ""00 0001/020/000084/1//82/"", ""coordinates"": {""x"": 10, ""y"": 270}},
                {""description"": ""PARA USTÜ *8,14"", ""coordinates"": {""x"": 10, ""y"": 280}},
                {""description"": ""KASİYER: 1"", ""coordinates"": {""x"": 10, ""y"": 290}},
                {""description"": ""2 NO:1330 EKÜ NO:0001"", ""coordinates"": {""x"": 10, ""y"": 300}},
                {""description"": ""MF YAB 15017876"", ""coordinates"": {""x"": 10, ""y"": 310}}
            ]
        }";

        var receipt = JsonConvert.DeserializeObject<Receipt>(jsonResponse);

        receipt.Items.Sort((a, b) => a.Coordinates.Y.CompareTo(b.Coordinates.Y));

        int lineNumber = 1;
        foreach (var item in receipt.Items)
        {
            Console.WriteLine($"{lineNumber} {item.Description}");
            lineNumber++;
        }
    }
}
