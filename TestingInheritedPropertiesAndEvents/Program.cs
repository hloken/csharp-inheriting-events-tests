using System;
using System.ComponentModel;

namespace TestingInheritedPropertiesAndEvents
{
    public class BaseWithoutVirtual
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Subscribers => PropertyChanged?.GetInvocationList().Length ?? 0;
    }

    public class DerivedWithoutNew : BaseWithoutVirtual
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Subscribers => PropertyChanged?.GetInvocationList().Length ?? 0;
    }

    public class DerivedWithNew : BaseWithoutVirtual
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        public new int Subscribers => PropertyChanged?.GetInvocationList().Length ?? 0;
    }

    public class BaseWithVirtual
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        public virtual int Subscribers => PropertyChanged?.GetInvocationList().Length ?? 0;
    }

    public class DerivedFromBaseWithVirtualWithoutNew : BaseWithVirtual
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Subscribers => PropertyChanged?.GetInvocationList().Length ?? 0;
    }

    public class DerivedFromBaseWithVirtualWithNew : BaseWithVirtual
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        public new int Subscribers => PropertyChanged?.GetInvocationList().Length ?? 0;
    }

    public class DerivedFromBaseWithVirtualWithOverride : BaseWithVirtual
    {
        public override event PropertyChangedEventHandler PropertyChanged;

        public override int Subscribers => PropertyChanged?.GetInvocationList().Length ?? 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            DerivedWithoutNew derivedWithoutNewReference = new DerivedWithoutNew();
            derivedWithoutNewReference.PropertyChanged += (s, a) =>
            {
                var banana = 0;

            };

            BaseWithoutVirtual baseWithoutVirtualReference = (BaseWithoutVirtual)derivedWithoutNewReference;
            baseWithoutVirtualReference.PropertyChanged += (s, a) =>
            {
                var apple = 1;
            };
            baseWithoutVirtualReference.PropertyChanged += (s, a) =>
            {
                var orange = 2;
            };

            Console.WriteLine($"DerivedWithoutNew subscriber count: {derivedWithoutNewReference.Subscribers}");
            Console.WriteLine($"BaseWithoutVirtual subscriber count: {baseWithoutVirtualReference.Subscribers}");

            var derivedWithNew = new DerivedWithNew();
            derivedWithNew.PropertyChanged += (s, a) =>
            {
                var banana = 0;

            };

            var baseWithoutVirtualReference2 = (BaseWithoutVirtual)derivedWithNew;
            baseWithoutVirtualReference2.PropertyChanged += (s, a) =>
            {
                var apple = 1;
            };
            baseWithoutVirtualReference2.PropertyChanged += (s, a) =>
            {
                var orange = 2;
            };

            Console.WriteLine($"DerivedWithNew subscriber count: {derivedWithNew.Subscribers}");
            Console.WriteLine($"Base2 subscriber count: {baseWithoutVirtualReference2.Subscribers}");

            var derivedFromBaseWithVirtualWithoutNew = new DerivedFromBaseWithVirtualWithoutNew();
            derivedFromBaseWithVirtualWithoutNew.PropertyChanged += (s, a) =>
            {
                var banana = 0;

            };

            var baseWithVirtual = (BaseWithVirtual)derivedFromBaseWithVirtualWithoutNew;
            baseWithVirtual.PropertyChanged += (s, a) =>
            {
                var apple = 1;
            };
            baseWithVirtual.PropertyChanged += (s, a) =>
            {
                var orange = 2;
            };

            Console.WriteLine($"DerivedFromBaseWithVirtualWithoutNew subscriber count: {derivedFromBaseWithVirtualWithoutNew.Subscribers}");
            Console.WriteLine($"baseWithVirtual subscriber count: {baseWithVirtual.Subscribers}");

            var derivedFromBaseWithVirtualWithNew = new DerivedFromBaseWithVirtualWithNew();
            derivedFromBaseWithVirtualWithNew.PropertyChanged += (s, a) =>
            {
                var banana = 0;

            };

            var baseWithVirtual2 = (BaseWithVirtual)derivedFromBaseWithVirtualWithNew;
            baseWithVirtual2.PropertyChanged += (s, a) =>
            {
                var apple = 1;
            };
            baseWithVirtual2.PropertyChanged += (s, a) =>
            {
                var orange = 2;
            };

            Console.WriteLine($"derivedFromBaseWithVirtualWithNew subscriber count: {derivedFromBaseWithVirtualWithNew.Subscribers}");
            Console.WriteLine($"baseWithVirtual2 subscriber count: {baseWithVirtual2.Subscribers}");

            var derivedFromBaseWithVirtualWithOverride = new DerivedFromBaseWithVirtualWithOverride();
            derivedFromBaseWithVirtualWithOverride.PropertyChanged += (s, a) =>
            {
                var banana = 0;

            };

            var baseWithVirtual3 = (BaseWithVirtual)derivedFromBaseWithVirtualWithOverride;
            baseWithVirtual3.PropertyChanged += (s, a) =>
            {
                var apple = 1;
            };
            baseWithVirtual3.PropertyChanged += (s, a) =>
            {
                var orange = 2;
            };

            Console.WriteLine($"derivedFromBaseWithVirtualWithOverride subscriber count: {derivedFromBaseWithVirtualWithOverride.Subscribers}");
            Console.WriteLine($"baseWithVirtual3 subscriber count: {baseWithVirtual3.Subscribers}");
        }
    }
}