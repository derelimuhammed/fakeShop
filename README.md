# Product Controller API

Bu controller, ürünlerle ilgili çeşitli işlemleri gerçekleştirmek için tasarlanmıştır. API, CRUD (Create, Read, Update, Delete) operasyonlarını destekler ve belirli izinlere tabi olabilir.

## Endpoints ve Kullanımı

### 1. Yeni Ürün Ekleme

- **HTTP Metodu**: POST
- **Route**: `/api/Product/Post`
- **Açıklama**: Yeni bir ürün eklemek için bu endpoint kullanılır.
- **Request Body**: Yeni ürün bilgilerini içeren JSON formatındaki veri.
- **Örnek Kullanım**:
    ```http
    POST /api/Product/Post
    {
        "productName": "Ürün Adı",
        "description": "Ürün Açıklaması",
        ...
    }
    ```

### 2. Tüm Ürünleri Getirme

- **HTTP Metodu**: GET
- **Route**: `/api/Product/GetAll`
- **Açıklama**: Tüm mevcut ürünleri getirmek için kullanılır. Bu endpoint'e sadece "Admin" yetkisine sahip kullanıcılar erişebilir.
- **Örnek Kullanım**:
    ```http
    GET /api/Product/GetAll
    ```

### 3. Sayfa Boyutuna Göre Ürünleri Getirme

- **HTTP Metodu**: GET
- **Route**: `/api/Product/GetByPageSize`
- **Açıklama**: Belirli bir sayfa boyutu kadar ürünleri getirmek için kullanılır.
- **Query Parametreleri**: `pageSize` (sayfa boyutu), `pageNumber` (sayfa numarası)
- **Örnek Kullanım**:
    ```http
    GET /api/Product/GetByPageSize?pageSize=10&pageNumber=1
    ```

### 4. Ürünü Güncelleme

- **HTTP Metodu**: PUT
- **Route**: `/api/Product/Update`
- **Açıklama**: Mevcut bir ürünü güncellemek için kullanılır.
- **Request Body**: Güncellenecek ürünün bilgilerini içeren JSON formatındaki veri.
- **Örnek Kullanım**:
    ```http
    PUT /api/Product/Update
    {
        "productId": 123,
        "productName": "Güncellenmiş Ürün Adı",
        "description": "Güncellenmiş Ürün Açıklaması",
        ...
    }
    ```

### 5. Ürünü Silme

- **HTTP Metodu**: DELETE
- **Route**: `/api/Product/Delete`
- **Açıklama**: Belirtilen bir ürünü silmek için kullanılır.
- **Request Body**: Silinecek ürüne ait bilgileri içeren JSON formatındaki veri.
- **Örnek Kullanım**:
    ```http
    DELETE /api/Product/Delete
    {
        "productId": 123
    }
    ```
# AppUser Controller API

Bu controller, kullanıcı yönetimi ile ilgili operasyonları gerçekleştirmek için tasarlanmıştır. Kullanıcı kaydı oluşturma ve giriş işlemlerini yönetir.

## Endpoints ve Kullanımı

### 1. Kullanıcı Kaydı Oluşturma

- **HTTP Metodu**: POST
- **Route**: `/api/AppUser/Register`
- **Açıklama**: Yeni bir kullanıcı kaydı oluşturmak için bu endpoint kullanılır.
- **Request Body**: Yeni kullanıcı bilgilerini içeren JSON formatındaki veri.
- **Örnek Kullanım**:
    ```http
    POST /api/AppUser/Register
    {
        "username": "kullanici_adi",
        "password": "sifre123",
        ...
    }
    ```
- **Cevaplar**:
    - Başarılı ise HTTP 200 OK ve başarılı mesaj döner.
    - Başarısız ise HTTP 400 Bad Request ve hata mesajı döner.

### 2. Kullanıcı Girişi

- **HTTP Metodu**: GET
- **Route**: `/api/AppUser/Login`
- **Açıklama**: Kayıtlı bir kullanıcı ile giriş yapmak için kullanılır.
- **Query Parametreleri**: Kullanıcı giriş bilgilerini içeren sorgu parametreleri.
- **Örnek Kullanım**:
    ```http
    GET /api/AppUser/Login?username=kullanici_adi&password=sifre123
    ```
- **Cevaplar**:
    - Başarılı ise HTTP 200 OK ve giriş başarılı mesajı döner.
    - Başarısız ise HTTP 400 Bad Request ve hata mesajı döner.

## Notlar

- Tüm istekler sonucunda dönen cevaplar JSON formatındadır.
- Kullanıcı kaydı oluşturma ve giriş işlemleri için gerekli parametreler ve veri yapıları belirtilmelidir.
- Identity'nin parola güvenliği için otomatik olarak hashleme ve tuzlama gibi güvenlik önlemleri alınır.
- Başarılı işlemlerde `OK` cevabı alınırken, hatalı durumlarda `Bad Request` cevabı döner.

Bu API, kullanıcı kayıt işlemleri ve giriş işlemleri için uygun parametrelerle kullanılmalıdır. Her bir endpoint'in kullanımı ve gereksinimleri önceden belirlenmelidir.


- Tüm istekler sonucunda dönen cevaplar JSON formatındadır.
- Bazı işlemler için özel yetkilere ihtiyaç duyulabilir (örneğin, tüm ürünleri getirme işlemi sadece "Admin" yetkisine sahip kullanıcılar için erişilebilirdir).

Bu API'nın kullanımı için uygun yetkilerle erişim sağlanmalıdır ve her bir endpoint'in kullanımı için gerekli parametreler ve veri yapıları dikkate alınmalıdır.
