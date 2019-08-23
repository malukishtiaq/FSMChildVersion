using FluentValidation;
using FSMChildVersion.Core.ViewModels;
using MvvmCross;
using MvvmCross.Commands;
using Plugin.FluentValidationRules;

namespace FSMChildVersion.Core.Validations
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public abstract class ValidationHandler<T> : BaseViewModel, IValidate<T>
    {
        public readonly IValidator Validator;
        public AbstractValidator<T> ValidationRules;
        public Validatables LoginValidatablesRef;
        public Validatables LoginValidatablesVal;
        private IMvxCommand<string> _clearValidationCommand;
        public IMvxCommand<string> ClearValidationCommand => _clearValidationCommand ?? (_clearValidationCommand = new MvxCommand<string>(ClearValidation));


        protected ValidationHandler(AbstractValidator<T> validationRules)
        {
            ValidationRules = validationRules;
            Validator = Mvx.IoCProvider.Resolve<IValidator>();
        }

        public void SetupForValidation()
        {
        }
        public void SetupForValidationRef<TType>(params Validatable<TType>[] list) where TType : class
        {
            LoginValidatablesRef = new Validatables(list);
        }
        public void SetupForValidationVal<TType>(params Validatable<TType>[] list) where TType : struct
        {
            LoginValidatablesVal = new Validatables(list);
        }
        public OverallValidationResult Validate(T login)
        {
            return ValidationRules.Validate(login).ApplyResultsTo(LoginValidatablesRef);
        }

        public void ClearValidation(string clearOptions = "")
        {
            if (clearOptions == "Xamarin.Forms.FocusEventArgs")
            {
                if (LoginValidatablesRef != null)
                    LoginValidatablesRef.Clear();
                if (LoginValidatablesVal != null)
                    LoginValidatablesVal.Clear();
            }
            else
            {
                (var clearOnlyValidation, var classPropertyNames) = clearOptions.ParseClearOptions();
                if (LoginValidatablesRef != null)
                    LoginValidatablesRef.Clear(clearOnlyValidation, classPropertyNames);
                if (LoginValidatablesVal != null)
                    LoginValidatablesVal.Clear(clearOnlyValidation, classPropertyNames);
            }
        }
    }
}
