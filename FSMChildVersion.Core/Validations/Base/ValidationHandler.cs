using System;
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
        public IValidator Validator;
        public AbstractValidator<T> ValidationRules;
        public Validatables RefrenceTypeValidatables;
        public Validatables ValueTypeValidatables;
        private IMvxCommand<string> _clearValidationCommand;
        public IMvxCommand<string> ClearValidationCommand => _clearValidationCommand ?? (_clearValidationCommand = new MvxCommand<string>(ClearValidation));


        protected ValidationHandler(AbstractValidator<T> validationRules)
        {
            ValidationRules = validationRules;
        }

        public void SetupForValidation()
        {
        }
        public void SetupForValidationRef<TType>(params Validatable<TType>[] list) where TType : class
        {
            RefrenceTypeValidatables = new Validatables(list);
        }
        public void SetupForValidationVal<TType>(params Validatable<TType>[] list) where TType : struct
        {
            ValueTypeValidatables = new Validatables(list);
        }
        public OverallValidationResult Validate(T login)
        {
            return ValidationRules.Validate(login).ApplyResultsTo(RefrenceTypeValidatables);
        }

        public void ClearValidation(string clearOptions = "")
        {
            if (clearOptions == "Xamarin.Forms.FocusEventArgs")
            {
                if (RefrenceTypeValidatables != null)
                    RefrenceTypeValidatables.Clear();
                if (ValueTypeValidatables != null)
                    ValueTypeValidatables.Clear();
            }
            else
            {
                (var clearOnlyValidation, var classPropertyNames) = clearOptions.ParseClearOptions();
                if (RefrenceTypeValidatables != null)
                    RefrenceTypeValidatables.Clear(clearOnlyValidation, classPropertyNames);
                if (ValueTypeValidatables != null)
                    ValueTypeValidatables.Clear(clearOnlyValidation, classPropertyNames);
            }
        }
    }
}
