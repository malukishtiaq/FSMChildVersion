using System;
using System.Windows.Input;
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
        public ICommand ClearValidationCommand => new MvxCommand<string>((value)=> ClearValidation(value));
         
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
            (var clearOnlyValidation, var classPropertyNames) = clearOptions.ParseClearOptions();
            if (LoginValidatablesRef != null)
                LoginValidatablesRef.Clear(clearOnlyValidation, classPropertyNames);
            if(LoginValidatablesVal != null)
                LoginValidatablesVal.Clear(clearOnlyValidation, classPropertyNames);
        }
    }
}
