using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Constants
{
    public static class Messages
    {
        public static string SuccessAddOperation { get => "Ekleme işlemi başarıyla sonuçlandı."; }
        public static string ErrorAddOperation { get => "Ekleme işlemi hatayla sonuçlandı"; }

        public static string SuccessDeleteOperation { get => "Silme işlemi başarıyla sonuçlandı."; }
        public static string ErrorDeleteOperation { get => "Silme işlemi başarıyla sonuçlandı."; }

        public static string SuccessUpdateOperation { get => "Güncelleme işlemi başarıyla sonuçlandı."; }
        public static string ErrorUpdateOperation { get => "Güncelleme işlemi başarıyla sonuçlandı."; }

        public static string SuccessLoginOperation { get => "Başarıyla giriş yaptınız"; }
        public static string ErrorLoginOperation { get => "Giriş yapmaya çalışırken bazı hatalar ile karşılaşıldı."; }

        public static string SuccessRegisterOperation { get => "Başarıyla kayıt oldunuz"; }
        public static string ErrorRegisterOperation { get => "Kayıt olmaya çalışırken bazı hatalar ile karşılaşıldı"; }

        public static string UserFound { get => "Kullanıcı başarıyla bulundu"; }
        public static string UserNotFound { get => "Kullanıcı bulunamadı"; }
        public static string CreatedAccessToken { get => "Token Başarıyla oluşturuldu"; }

        public static string InternelServerError { get => "Internel Server Error!";}
        public static string AuthorizationDenied { get => "Yetkiniz yok." ;}
    }
}
