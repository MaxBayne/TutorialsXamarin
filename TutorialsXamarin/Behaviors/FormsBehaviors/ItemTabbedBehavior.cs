using TutorialsXamarin.Common.Models;
using Xamarin.Forms;

namespace TutorialsXamarin.Behaviors.FormsBehaviors
{
    public class ItemSelectedBehavior : Behavior<CollectionView>
    {
        //Fire When Behavior Added To Control , Perform Setup For Behavior like register events
        protected override void OnAttachedTo(CollectionView collectionView)
        {
            base.OnAttachedTo(collectionView);

            //Perform Setup Here -------

            collectionView.SelectionChanged += CollectionView_SelectionChanged;
        }

        

        //Fire When Behavior Removed From Control ,Perform Cleanup For Behavior like un-register events
        protected override void OnDetachingFrom(CollectionView collectionView)
        {
            base.OnDetachingFrom(collectionView);

            //Perform Cleanup Here -------
            collectionView.SelectionChanged -= CollectionView_SelectionChanged;
        }

        //Behavior Implementations
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cusomer = e.CurrentSelection[0] as Customer;

            if (cusomer != null)
            {
                cusomer.FirstName = "Tester Man";
            }

        }


    }
}
