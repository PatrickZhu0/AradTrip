using System;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A08 RID: 18952
	[ExecuteInEditMode]
	public class BoundingBoxFollower : MonoBehaviour
	{
		// Token: 0x17002431 RID: 9265
		// (get) Token: 0x0601B5BC RID: 112060 RVA: 0x0086E2C3 File Offset: 0x0086C6C3
		public Slot Slot
		{
			get
			{
				return this.slot;
			}
		}

		// Token: 0x17002432 RID: 9266
		// (get) Token: 0x0601B5BD RID: 112061 RVA: 0x0086E2CB File Offset: 0x0086C6CB
		public BoundingBoxAttachment CurrentAttachment
		{
			get
			{
				return this.currentAttachment;
			}
		}

		// Token: 0x17002433 RID: 9267
		// (get) Token: 0x0601B5BE RID: 112062 RVA: 0x0086E2D3 File Offset: 0x0086C6D3
		public string CurrentAttachmentName
		{
			get
			{
				return this.currentAttachmentName;
			}
		}

		// Token: 0x17002434 RID: 9268
		// (get) Token: 0x0601B5BF RID: 112063 RVA: 0x0086E2DB File Offset: 0x0086C6DB
		public PolygonCollider2D CurrentCollider
		{
			get
			{
				return this.currentCollider;
			}
		}

		// Token: 0x17002435 RID: 9269
		// (get) Token: 0x0601B5C0 RID: 112064 RVA: 0x0086E2E3 File Offset: 0x0086C6E3
		public bool IsTrigger
		{
			get
			{
				return this.isTrigger;
			}
		}

		// Token: 0x0601B5C1 RID: 112065 RVA: 0x0086E2EB File Offset: 0x0086C6EB
		private void Start()
		{
			this.Initialize(false);
		}

		// Token: 0x0601B5C2 RID: 112066 RVA: 0x0086E2F4 File Offset: 0x0086C6F4
		private void OnEnable()
		{
			if (this.skeletonRenderer != null)
			{
				this.skeletonRenderer.OnRebuild -= this.HandleRebuild;
				this.skeletonRenderer.OnRebuild += this.HandleRebuild;
			}
			this.Initialize(false);
		}

		// Token: 0x0601B5C3 RID: 112067 RVA: 0x0086E347 File Offset: 0x0086C747
		private void HandleRebuild(SkeletonRenderer sr)
		{
			this.Initialize(false);
		}

		// Token: 0x0601B5C4 RID: 112068 RVA: 0x0086E350 File Offset: 0x0086C750
		public void Initialize(bool overwrite = false)
		{
			if (this.skeletonRenderer == null)
			{
				return;
			}
			this.skeletonRenderer.Initialize(false);
			if (string.IsNullOrEmpty(this.slotName))
			{
				return;
			}
			if (!overwrite && this.colliderTable.Count > 0 && this.slot != null && this.skeletonRenderer.skeleton == this.slot.Skeleton && this.slotName == this.slot.data.name)
			{
				return;
			}
			this.DisposeColliders();
			Skeleton skeleton = this.skeletonRenderer.skeleton;
			this.slot = skeleton.FindSlot(this.slotName);
			int slotIndex = skeleton.FindSlotIndex(this.slotName);
			if (this.slot == null)
			{
				if (BoundingBoxFollower.DebugMessages)
				{
					Debug.LogWarning(string.Format("Slot '{0}' not found for BoundingBoxFollower on '{1}'. (Previous colliders were disposed.)", this.slotName, base.gameObject.name));
				}
				return;
			}
			if (base.gameObject.activeInHierarchy)
			{
				foreach (Skin skin in skeleton.Data.Skins)
				{
					this.AddSkin(skin, slotIndex);
				}
				if (skeleton.skin != null)
				{
					this.AddSkin(skeleton.skin, slotIndex);
				}
			}
			if (BoundingBoxFollower.DebugMessages && this.colliderTable.Count == 0)
			{
				if (base.gameObject.activeInHierarchy)
				{
					Debug.LogWarning("Bounding Box Follower not valid! Slot [" + this.slotName + "] does not contain any Bounding Box Attachments!");
				}
				else
				{
					Debug.LogWarning("Bounding Box Follower tried to rebuild as a prefab.");
				}
			}
		}

		// Token: 0x0601B5C5 RID: 112069 RVA: 0x0086E52C File Offset: 0x0086C92C
		private void AddSkin(Skin skin, int slotIndex)
		{
			if (skin == null)
			{
				return;
			}
			List<string> list = new List<string>();
			skin.FindNamesForSlot(slotIndex, list);
			foreach (string text in list)
			{
				Attachment attachment = skin.GetAttachment(slotIndex, text);
				BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
				if (BoundingBoxFollower.DebugMessages && attachment != null && boundingBoxAttachment == null)
				{
					Debug.Log("BoundingBoxFollower tried to follow a slot that contains non-boundingbox attachments: " + this.slotName);
				}
				if (boundingBoxAttachment != null && !this.colliderTable.ContainsKey(boundingBoxAttachment))
				{
					PolygonCollider2D polygonCollider2D = SkeletonUtility.AddBoundingBoxAsComponent(boundingBoxAttachment, this.slot, base.gameObject, this.isTrigger, true, 0f);
					polygonCollider2D.enabled = false;
					polygonCollider2D.hideFlags = 8;
					polygonCollider2D.isTrigger = this.IsTrigger;
					this.colliderTable.Add(boundingBoxAttachment, polygonCollider2D);
					this.nameTable.Add(boundingBoxAttachment, text);
				}
			}
		}

		// Token: 0x0601B5C6 RID: 112070 RVA: 0x0086E644 File Offset: 0x0086CA44
		private void OnDisable()
		{
			if (this.clearStateOnDisable)
			{
				this.ClearState();
			}
		}

		// Token: 0x0601B5C7 RID: 112071 RVA: 0x0086E658 File Offset: 0x0086CA58
		public void ClearState()
		{
			if (this.colliderTable != null)
			{
				foreach (PolygonCollider2D polygonCollider2D in this.colliderTable.Values)
				{
					polygonCollider2D.enabled = false;
				}
			}
			this.currentAttachment = null;
			this.currentAttachmentName = null;
			this.currentCollider = null;
		}

		// Token: 0x0601B5C8 RID: 112072 RVA: 0x0086E6DC File Offset: 0x0086CADC
		private void DisposeColliders()
		{
			PolygonCollider2D[] components = base.GetComponents<PolygonCollider2D>();
			if (components.Length == 0)
			{
				return;
			}
			if (Application.isEditor)
			{
				if (Application.isPlaying)
				{
					foreach (PolygonCollider2D polygonCollider2D in components)
					{
						if (polygonCollider2D != null)
						{
							Object.Destroy(polygonCollider2D);
						}
					}
				}
				else
				{
					foreach (PolygonCollider2D polygonCollider2D2 in components)
					{
						if (polygonCollider2D2 != null)
						{
							Object.DestroyImmediate(polygonCollider2D2);
						}
					}
				}
			}
			else
			{
				foreach (PolygonCollider2D polygonCollider2D3 in components)
				{
					if (polygonCollider2D3 != null)
					{
						Object.Destroy(polygonCollider2D3);
					}
				}
			}
			this.slot = null;
			this.currentAttachment = null;
			this.currentAttachmentName = null;
			this.currentCollider = null;
			this.colliderTable.Clear();
			this.nameTable.Clear();
		}

		// Token: 0x0601B5C9 RID: 112073 RVA: 0x0086E7E3 File Offset: 0x0086CBE3
		private void LateUpdate()
		{
			if (this.slot != null && this.slot.Attachment != this.currentAttachment)
			{
				this.MatchAttachment(this.slot.Attachment);
			}
		}

		// Token: 0x0601B5CA RID: 112074 RVA: 0x0086E818 File Offset: 0x0086CC18
		private void MatchAttachment(Attachment attachment)
		{
			BoundingBoxAttachment boundingBoxAttachment = attachment as BoundingBoxAttachment;
			if (BoundingBoxFollower.DebugMessages && attachment != null && boundingBoxAttachment == null)
			{
				Debug.LogWarning("BoundingBoxFollower tried to match a non-boundingbox attachment. It will treat it as null.");
			}
			if (this.currentCollider != null)
			{
				this.currentCollider.enabled = false;
			}
			if (boundingBoxAttachment == null)
			{
				this.currentCollider = null;
				this.currentAttachment = null;
				this.currentAttachmentName = null;
			}
			else
			{
				PolygonCollider2D polygonCollider2D;
				this.colliderTable.TryGetValue(boundingBoxAttachment, out polygonCollider2D);
				if (polygonCollider2D != null)
				{
					this.currentCollider = polygonCollider2D;
					this.currentCollider.enabled = true;
					this.currentAttachment = boundingBoxAttachment;
					this.currentAttachmentName = this.nameTable[boundingBoxAttachment];
				}
				else
				{
					this.currentCollider = null;
					this.currentAttachment = boundingBoxAttachment;
					this.currentAttachmentName = null;
					if (BoundingBoxFollower.DebugMessages)
					{
						Debug.LogFormat("Collider for BoundingBoxAttachment named '{0}' was not initialized. It is possibly from a new skin. currentAttachmentName will be null. You may need to call BoundingBoxFollower.Initialize(overwrite: true);", new object[]
						{
							boundingBoxAttachment.Name
						});
					}
				}
			}
		}

		// Token: 0x040130B5 RID: 78005
		internal static bool DebugMessages = true;

		// Token: 0x040130B6 RID: 78006
		public SkeletonRenderer skeletonRenderer;

		// Token: 0x040130B7 RID: 78007
		[SpineSlot("", "skeletonRenderer", true, true, false)]
		public string slotName;

		// Token: 0x040130B8 RID: 78008
		public bool isTrigger;

		// Token: 0x040130B9 RID: 78009
		public bool clearStateOnDisable = true;

		// Token: 0x040130BA RID: 78010
		private Slot slot;

		// Token: 0x040130BB RID: 78011
		private BoundingBoxAttachment currentAttachment;

		// Token: 0x040130BC RID: 78012
		private string currentAttachmentName;

		// Token: 0x040130BD RID: 78013
		private PolygonCollider2D currentCollider;

		// Token: 0x040130BE RID: 78014
		public readonly Dictionary<BoundingBoxAttachment, PolygonCollider2D> colliderTable = new Dictionary<BoundingBoxAttachment, PolygonCollider2D>();

		// Token: 0x040130BF RID: 78015
		public readonly Dictionary<BoundingBoxAttachment, string> nameTable = new Dictionary<BoundingBoxAttachment, string>();
	}
}
