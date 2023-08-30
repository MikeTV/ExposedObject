namespace TestSubjects
{
    public class BaseClass
    {
        #pragma warning disable CA1051 // Do not declare visible instance fields
        protected string _field = nameof(BaseClass);
        #pragma warning restore CA1051 // Do not declare visible instance fields

        protected string Property
        {
            get
            {
                return _field;
            }
            set
            {
                _field = value;
            }
        }
        protected string Method() => _field;


        public virtual string OverriddenMethod() => nameof(BaseClass);
        public virtual string OverriddenProperty => nameof(BaseClass);

        public string HiddenMethod() => nameof(BaseClass);

        public string HiddenProperty => nameof(BaseClass);

#pragma warning disable CA1051 // Do not declare visible instance fields
        protected string _hiddenField = nameof(BaseClass);
#pragma warning restore CA1051 // Do not declare visible instance fields
    }

    public class ChildClass : BaseClass
    {
        public ChildClass()
        {
            _field = nameof(ChildClass);
        }

        public override string OverriddenMethod() => nameof(ChildClass);
        public override string OverriddenProperty => nameof(ChildClass);

        public new string HiddenMethod() => nameof(ChildClass);

        public new string HiddenProperty => nameof(ChildClass);

#pragma warning disable CA1051 // Do not declare visible instance fields
        protected new string _hiddenField = nameof(ChildClass);
#pragma warning restore CA1051 // Do not declare visible instance fields
    }
}
