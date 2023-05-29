using ShuttleServiceManagementApp.Domain.Shared;

namespace ShuttleServiceManagementApp.Domain.Errors
{
    public static class DomainErrors
    {
        public static class DriverName
        {
            public static readonly Error Empty = new("DriverName.Empty", "ورود نام راننده الزامی است.");
            public static readonly Error MaxLength = new("DriverName.MaxLength", "تعداد کاراکترهای نام راننده بیش از حد مجاز است.");
        }
        public static class Name
        {
            public static readonly Error Empty = new("Name.Empty", "ورود نام الزامی است.");
            public static readonly Error MaxLength = new("Name.MaxLength", "تعداد کاراکترهای نام بیش از حد مجاز است.");
        }
        public static class Bus
        {
            public static readonly Error NotFound = new("Bus.NotFound", "اتوبوس مورد نظر پیدا نشد.");
            public static class Capacity
            {
                public static readonly Error Required = new("Bus.Capacity.Required", "ورود ظرفیت اتوبوس الزامی است.");
            }
        }
        public static class TimingCategory
        {
            public static class Title
            {
                public static readonly Error Repeated = new("TimingCategory.Title.Repeated", "نام شیفت تکراری است.");
            }
            public static readonly Error NotFound = new("TimingCategory.NotFound", "شیفت مورد نظر پیدا نشد.");
        }
    }
}
