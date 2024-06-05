Soru 1-)
Prosedür: generate_codes
Amaç:
Belirlenen karakter kümesinden rastgele 8 karakterli, 1000 adet benzersiz kod oluşturur ve bunları döner.

Değişkenler:
@CodeCount INT: Üretilen kod sayısını takip eder (başlangıç değeri 0).
@Code VARCHAR(8): Geçici olarak her bir kodu oluşturmak için kullanılır.
@CharacterSet VARCHAR(25): Kod oluşturmak için kullanılan karakter kümesi ('ACDEFGHKLMNPRTXYZ234579').
Geçici Tablo:
#GeneratedCodes: Üretilen kodları saklar. Code sütunu birincil anahtardır.

Adımlar:
Geçici Tablo Oluşturma:

#GeneratedCodes tablosu oluşturulur ve Code sütunu birincil anahtar olarak belirlenir.

Kod Üretme Döngüsü:

@CodeCount 1000'e ulaşana kadar devam eder.
Her döngüde @Code sıfırlanır ve iç döngü ile 8 karakterli kod oluşturulur.
Kodun benzersiz olup olmadığı kontrol edilir.
Benzersizse tabloya eklenir ve @CodeCount artırılır.

Kodları Seçme:

SELECT Code FROM #GeneratedCodes ile üretilen kodlar döner.
Geçici Tabloyu Silme:

#GeneratedCodes tablosu silinir.


![1](https://github.com/Sefa728/KaizenCaseStudy/assets/44734496/32fc7454-f16d-412f-acb4-24b3da58ba43)


Prosedür: check_code
Amaç:
Verilen 8 karakterli kodun geçerli olup olmadığını kontrol eder ve sonucu bir çıktı parametresinde döner.

Parametreler:
@Code VARCHAR(8): Kontrol edilecek kod.
@IsValid INT OUTPUT: Kodun geçerli olup olmadığını belirten çıktı parametresi (1: geçerli, 0: geçersiz).
Adımlar:
Kod Uzunluğunu Kontrol Etme:

Kodun uzunluğu 8 karakter değilse, @IsValid 0 olarak ayarlanır ve prosedür sonlandırılır.
Karakter Kümesini Tanımlama:

@CharacterSet değişkeni, geçerli karakterleri içerir ('ACDEFGHKLMNPRTXYZ234579').
Kodun Her Bir Karakterini Kontrol Etme:

Kodun her bir karakteri için:
Karakter, @CharacterSet içinde bulunmuyorsa, @IsValid 0 olarak ayarlanır ve prosedür sonlandırılır.
Aksi takdirde, sonraki karakter kontrol edilir.
Geçerli Kod:

Tüm karakterler kontrol edildikten sonra, @IsValid 1 olarak ayarlanır.


![2](https://github.com/Sefa728/KaizenCaseStudy/assets/44734496/7cf1fcdb-13b8-4eae-aecb-adc4c12dae94)
![3](https://github.com/Sefa728/KaizenCaseStudy/assets/44734496/12c94a27-6b09-43c8-920a-fe91c28d7b88)

Soru 2-)
Receipt OCR JSON Parsing Kodu
Amaç
Bu program, bir OCR (Optik Karakter Tanıma) sisteminden gelen JSON formatındaki veriyi alarak parse eder ve fiş üzerinde görünen metinleri koordinat bilgilerine göre sıralar. Sıralanmış metinleri, fişteki görünüm sırasına göre konsolda gösterir.

Kullanılan Kütüphaneler
System: Temel giriş/çıkış işlemleri ve veri türleri için kullanılır.
System.Collections.Generic: List gibi koleksiyonlar için kullanılır.
Newtonsoft.Json: JSON verilerini parse etmek ve nesnelere dönüştürmek için kullanılır.

Sınıflar
ReceiptItem
Description: Metin içeriğini tutar.
Coordinates: Metnin fiş üzerindeki koordinatlarını tutar.
Coordinates
X: X koordinatını tutar.
Y: Y koordinatını tutar.
Receipt
Items: ReceiptItem nesnelerinden oluşan bir liste tutar.

Program Akışı
JSON Verisinin Tanımlanması:
JSON formatındaki örnek veri jsonResponse adlı string değişkeninde tanımlanır. Bu veri, fiş üzerindeki metinlerin açıklamalarını ve koordinat bilgilerini içerir.

JSON Parsing:
JsonConvert.DeserializeObject<Receipt>(jsonResponse) metodu ile JSON verisi, Receipt nesnesine dönüştürülür.

Koordinatlara Göre Sıralama:
Items listesi, her bir ReceiptItem nesnesinin Y koordinatına göre sıralanır. Bu işlem receipt.Items.Sort((a, b) => a.Coordinates.Y.CompareTo(b.Coordinates.Y)) kod satırı ile yapılır.

Verinin Konsola Yazdırılması:
Sıralanmış ReceiptItem nesneleri, birer birer konsola yazdırılır. Başlangıçta "line text" başlıkları ekrana yazdırılır ve ardından her bir metin satırı, koordinat sırasına göre numaralandırılarak gösterilir.

![4](https://github.com/Sefa728/KaizenCaseStudy/assets/44734496/2a06af4f-88ee-4404-a94a-194f69f07131)

