using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x020049E4 RID: 18916
	[CreateAssetMenu(menuName = "Spine/EventData Reference Asset")]
	public class EventDataReferenceAsset : ScriptableObject
	{
		// Token: 0x17002417 RID: 9239
		// (get) Token: 0x0601B49F RID: 111775 RVA: 0x00866560 File Offset: 0x00864960
		public EventData EventData
		{
			get
			{
				if (this.eventData == null)
				{
					this.Initialize();
				}
				return this.eventData;
			}
		}

		// Token: 0x0601B4A0 RID: 111776 RVA: 0x0086657C File Offset: 0x0086497C
		public void Initialize()
		{
			if (this.skeletonDataAsset == null)
			{
				return;
			}
			this.eventData = this.skeletonDataAsset.GetSkeletonData(true).FindEvent(this.eventName);
			if (this.eventData == null)
			{
				Debug.LogWarningFormat("Event Data '{0}' not found in SkeletonData : {1}.", new object[]
				{
					this.eventName,
					this.skeletonDataAsset.name
				});
			}
		}

		// Token: 0x0601B4A1 RID: 111777 RVA: 0x008665EA File Offset: 0x008649EA
		public static implicit operator EventData(EventDataReferenceAsset asset)
		{
			return asset.EventData;
		}

		// Token: 0x04013018 RID: 77848
		private const bool QuietSkeletonData = true;

		// Token: 0x04013019 RID: 77849
		[SerializeField]
		protected SkeletonDataAsset skeletonDataAsset;

		// Token: 0x0401301A RID: 77850
		[SerializeField]
		[SpineEvent("", "skeletonDataAsset", true, false)]
		protected string eventName;

		// Token: 0x0401301B RID: 77851
		private EventData eventData;
	}
}
