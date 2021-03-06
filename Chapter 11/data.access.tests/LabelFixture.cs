using DataAccess;
using DataModel;
using NUnit.Framework;

namespace Entities
{
	[TestFixture]
	public class LabelFixture : DatabaseFixture
	{
		private static readonly string labelName = "Label Name";

		private long labelId;
		private LabelGateway gateway;
		private RecordingDataSet recordingDataSet;

		public override void Insert()
		{
			recordingDataSet = new RecordingDataSet();
			gateway = new LabelGateway(Connection);
			labelId = gateway.Insert(recordingDataSet,labelName);
		}

		[Test]
		public void RetrieveLabelFromDatabase()
		{
			RecordingDataSet loadedFromDB = new RecordingDataSet();
			RecordingDataSet.Label loadedLabel = gateway.FindById(labelId, loadedFromDB);
			Assert.AreEqual(labelId,loadedLabel.Id);
			Assert.AreEqual(labelName, loadedLabel.Name);
		}

		[Test]
		public void DeleteLabelFromDatabase()
		{
			RecordingDataSet emptyDataSet = new RecordingDataSet();
			long deletedLabelId = gateway.Insert(emptyDataSet,"Deleted Label");
			gateway.Delete(emptyDataSet,deletedLabelId);

			RecordingDataSet.Label deleletedLabel = gateway.FindById(deletedLabelId, emptyDataSet);
			Assert.IsNull(deleletedLabel);
		}

		[Test]
		public void UpdateLableNameInDatabase()
		{
			RecordingDataSet.Label label = recordingDataSet.Labels[0];
			label.Name = "Modified Name";
			gateway.Update(recordingDataSet);

			RecordingDataSet updatedDataSet = new RecordingDataSet();
			RecordingDataSet.Label updatedLabel = gateway.FindById(labelId, updatedDataSet);
			Assert.AreEqual("Modified Name", updatedLabel.Name);
		}
	}
}