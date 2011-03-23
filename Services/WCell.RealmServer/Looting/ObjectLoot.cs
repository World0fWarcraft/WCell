using System;
using System.Linq;
using WCell.Util.Logging;
using WCell.Constants;
using WCell.Constants.Items;
using WCell.RealmServer.Entities;
using WCell.RealmServer.GameObjects.GOEntries;
using WCell.Constants.Looting;

namespace WCell.RealmServer.Looting
{
	/// <summary>
	/// TODO: Implement seperated loot for everyone when looting Quest-objects
	/// </summary>
	public class ObjectLoot : Loot
	{
		private static Logger log = LogManager.GetCurrentClassLogger();
		internal Action OnLootFinish;

		public ObjectLoot()
		{
		}

		public ObjectLoot(ILootable looted, uint money, LootItem[] items)
			: base(looted, money, items)
		{
		}

		public override LootResponseType ResponseType
		{
			get { return LootResponseType.Profession; }
		}

		protected override void OnDispose()
		{
			if (OnLootFinish != null)
			{
				OnLootFinish();
				OnLootFinish = null;
			}
			base.OnDispose();
		}
	}
}