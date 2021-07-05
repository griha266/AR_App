using ARApp.Common.Model;

namespace ARApp.Tracking
{
    public class TrackingModeModel : Model<TrackingMode>, ITrackingModeModel
    {
        public TrackingModeModel(TrackingMode initialState) : base(initialState) { }

        public void ChangeTracking(TrackingMode trackingMode) => ChangeState(trackingMode);
    }
}