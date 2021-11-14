using Xamarin.Forms;

namespace TutorialsXamarin.Behaviors.AttachedBehaviors
{
    public class NumericValidationBehavior
    {
        /*
         *using this attached behavior
         *
         * first Way :-----------
         * by attached property inside xaml
         * To Enable the Behavior :
         * <Entry Placeholder="Enter Number" attachedBehaviors:NumericValidationBehavior.AttachBehavior="True" />
         * To Disable the Behavior:
         * <Entry Placeholder="Enter Number" attachedBehaviors:NumericValidationBehavior.AttachBehavior="False" />
         *
         *         
         * Second Way:-----------
         * by hardcode C#
         * To Enable the Behavior
         * NumericValidationBehavior.SetAttachBehavior (entry, true);
         * To Disable the Behavior
         * NumericValidationBehavior.SetAttachBehavior (entry, false);
         */


        #region Control Behavior

        public static readonly BindableProperty AttachBehaviorProperty = BindableProperty.CreateAttached(
            propertyName: "AttachBehavior",
            returnType: typeof(bool),
            declaringType: typeof(NumericValidationBehavior),
            defaultValue: false,
            propertyChanged: OnAttachBehaviorPropertyChanged);



        //When AttachedBehavior BindableProperty Changed , used to activate or deactivate the behavior depend on the value of AttachedBehavior Property
        private static void OnAttachBehaviorPropertyChanged(BindableObject view, object oldvalue, object newvalue)
        {
            var entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newvalue;

            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        //Add or Remove the behavior using Hard Code , set true to add the behavior otherwise set false to remove the behavior
        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }
        //Read the Value of AttachedProperty
        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        #endregion

        #region Implementation Of Behavior

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = double.TryParse(args.NewTextValue, out _);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }

        #endregion
    }
}
