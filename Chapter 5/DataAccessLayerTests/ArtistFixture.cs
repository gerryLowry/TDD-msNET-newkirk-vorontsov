using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using NUnit.Framework;

namespace Entities
{
	[TestFixture]
	public class ArtistFixture : ConnectionFixture
	{
		private static readonly string artistName = "Artist";
		private ArtistGateway gateway; 
		private RecordingDataSet recordingDataSet;
		private long artistId; 

		[SetUp]
		public void SetUp()
		{
			recordingDataSet = new RecordingDataSet();
			gateway = new ArtistGateway(Connection);

			artistId = gateway.Insert(recordingDataSet,artistName);
		}

		[TearDown]
		public void TearDown()
		{
			gateway.Delete(recordingDataSet, artistId);
		}

		[Test]
		public void RetrieveArtistFromDatabase()
		{
			RecordingDataSet loadedFromDB = new RecordingDataSet();
			RecordingDataSet.Artist loadedArtist = 
				gateway.FindById(artistId, loadedFromDB);

			Assert.AreEqual(artistId,loadedArtist.Id);
			Assert.AreEqual(artistName, loadedArtist.Name);	
		}

		[Test]
		public void DeleteArtistFromDatabase()
		{
			RecordingDataSet emptyDataSet = new RecordingDataSet();
			long deletedArtistId = gateway.Insert(emptyDataSet,"Deleted Artist");
			gateway.Delete(emptyDataSet,deletedArtistId);

			RecordingDataSet.Artist deleletedArtist = 
				gateway.FindById(deletedArtistId, emptyDataSet);
			Assert.IsNull(deleletedArtist);
		}

		[Test]
		public void UpdateArtistInDatabase()
		{
			RecordingDataSet.Artist artist = recordingDataSet.Artists[0];
			artist.Name = "Modified Name";
			gateway.Update(recordingDataSet);
   
			RecordingDataSet updatedDataSet = new RecordingDataSet();
			RecordingDataSet.Artist updatedArtist = gateway.FindById(artistId, updatedDataSet);
			Assert.AreEqual("Modified Name", updatedArtist.Name);
		}
	}
}

