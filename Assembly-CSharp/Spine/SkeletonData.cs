using System;

namespace Spine
{
	// Token: 0x020049D6 RID: 18902
	public class SkeletonData
	{
		// Token: 0x170023CE RID: 9166
		// (get) Token: 0x0601B3D3 RID: 111571 RVA: 0x00860B5B File Offset: 0x0085EF5B
		// (set) Token: 0x0601B3D4 RID: 111572 RVA: 0x00860B63 File Offset: 0x0085EF63
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		// Token: 0x170023CF RID: 9167
		// (get) Token: 0x0601B3D5 RID: 111573 RVA: 0x00860B6C File Offset: 0x0085EF6C
		public ExposedList<BoneData> Bones
		{
			get
			{
				return this.bones;
			}
		}

		// Token: 0x170023D0 RID: 9168
		// (get) Token: 0x0601B3D6 RID: 111574 RVA: 0x00860B74 File Offset: 0x0085EF74
		public ExposedList<SlotData> Slots
		{
			get
			{
				return this.slots;
			}
		}

		// Token: 0x170023D1 RID: 9169
		// (get) Token: 0x0601B3D7 RID: 111575 RVA: 0x00860B7C File Offset: 0x0085EF7C
		// (set) Token: 0x0601B3D8 RID: 111576 RVA: 0x00860B84 File Offset: 0x0085EF84
		public ExposedList<Skin> Skins
		{
			get
			{
				return this.skins;
			}
			set
			{
				this.skins = value;
			}
		}

		// Token: 0x170023D2 RID: 9170
		// (get) Token: 0x0601B3D9 RID: 111577 RVA: 0x00860B8D File Offset: 0x0085EF8D
		// (set) Token: 0x0601B3DA RID: 111578 RVA: 0x00860B95 File Offset: 0x0085EF95
		public Skin DefaultSkin
		{
			get
			{
				return this.defaultSkin;
			}
			set
			{
				this.defaultSkin = value;
			}
		}

		// Token: 0x170023D3 RID: 9171
		// (get) Token: 0x0601B3DB RID: 111579 RVA: 0x00860B9E File Offset: 0x0085EF9E
		// (set) Token: 0x0601B3DC RID: 111580 RVA: 0x00860BA6 File Offset: 0x0085EFA6
		public ExposedList<EventData> Events
		{
			get
			{
				return this.events;
			}
			set
			{
				this.events = value;
			}
		}

		// Token: 0x170023D4 RID: 9172
		// (get) Token: 0x0601B3DD RID: 111581 RVA: 0x00860BAF File Offset: 0x0085EFAF
		// (set) Token: 0x0601B3DE RID: 111582 RVA: 0x00860BB7 File Offset: 0x0085EFB7
		public ExposedList<Animation> Animations
		{
			get
			{
				return this.animations;
			}
			set
			{
				this.animations = value;
			}
		}

		// Token: 0x170023D5 RID: 9173
		// (get) Token: 0x0601B3DF RID: 111583 RVA: 0x00860BC0 File Offset: 0x0085EFC0
		// (set) Token: 0x0601B3E0 RID: 111584 RVA: 0x00860BC8 File Offset: 0x0085EFC8
		public ExposedList<IkConstraintData> IkConstraints
		{
			get
			{
				return this.ikConstraints;
			}
			set
			{
				this.ikConstraints = value;
			}
		}

		// Token: 0x170023D6 RID: 9174
		// (get) Token: 0x0601B3E1 RID: 111585 RVA: 0x00860BD1 File Offset: 0x0085EFD1
		// (set) Token: 0x0601B3E2 RID: 111586 RVA: 0x00860BD9 File Offset: 0x0085EFD9
		public ExposedList<TransformConstraintData> TransformConstraints
		{
			get
			{
				return this.transformConstraints;
			}
			set
			{
				this.transformConstraints = value;
			}
		}

		// Token: 0x170023D7 RID: 9175
		// (get) Token: 0x0601B3E3 RID: 111587 RVA: 0x00860BE2 File Offset: 0x0085EFE2
		// (set) Token: 0x0601B3E4 RID: 111588 RVA: 0x00860BEA File Offset: 0x0085EFEA
		public ExposedList<PathConstraintData> PathConstraints
		{
			get
			{
				return this.pathConstraints;
			}
			set
			{
				this.pathConstraints = value;
			}
		}

		// Token: 0x170023D8 RID: 9176
		// (get) Token: 0x0601B3E5 RID: 111589 RVA: 0x00860BF3 File Offset: 0x0085EFF3
		// (set) Token: 0x0601B3E6 RID: 111590 RVA: 0x00860BFB File Offset: 0x0085EFFB
		public float Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		// Token: 0x170023D9 RID: 9177
		// (get) Token: 0x0601B3E7 RID: 111591 RVA: 0x00860C04 File Offset: 0x0085F004
		// (set) Token: 0x0601B3E8 RID: 111592 RVA: 0x00860C0C File Offset: 0x0085F00C
		public float Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
			}
		}

		// Token: 0x170023DA RID: 9178
		// (get) Token: 0x0601B3E9 RID: 111593 RVA: 0x00860C15 File Offset: 0x0085F015
		// (set) Token: 0x0601B3EA RID: 111594 RVA: 0x00860C1D File Offset: 0x0085F01D
		public string Version
		{
			get
			{
				return this.version;
			}
			set
			{
				this.version = value;
			}
		}

		// Token: 0x170023DB RID: 9179
		// (get) Token: 0x0601B3EB RID: 111595 RVA: 0x00860C26 File Offset: 0x0085F026
		// (set) Token: 0x0601B3EC RID: 111596 RVA: 0x00860C2E File Offset: 0x0085F02E
		public string Hash
		{
			get
			{
				return this.hash;
			}
			set
			{
				this.hash = value;
			}
		}

		// Token: 0x170023DC RID: 9180
		// (get) Token: 0x0601B3ED RID: 111597 RVA: 0x00860C37 File Offset: 0x0085F037
		// (set) Token: 0x0601B3EE RID: 111598 RVA: 0x00860C3F File Offset: 0x0085F03F
		public string ImagesPath
		{
			get
			{
				return this.imagesPath;
			}
			set
			{
				this.imagesPath = value;
			}
		}

		// Token: 0x170023DD RID: 9181
		// (get) Token: 0x0601B3EF RID: 111599 RVA: 0x00860C48 File Offset: 0x0085F048
		// (set) Token: 0x0601B3F0 RID: 111600 RVA: 0x00860C50 File Offset: 0x0085F050
		public float Fps
		{
			get
			{
				return this.fps;
			}
			set
			{
				this.fps = value;
			}
		}

		// Token: 0x0601B3F1 RID: 111601 RVA: 0x00860C5C File Offset: 0x0085F05C
		public BoneData FindBone(string boneName)
		{
			if (boneName == null)
			{
				throw new ArgumentNullException("boneName", "boneName cannot be null.");
			}
			ExposedList<BoneData> exposedList = this.bones;
			BoneData[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				BoneData boneData = items[i];
				if (boneData.name == boneName)
				{
					return boneData;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3F2 RID: 111602 RVA: 0x00860CC4 File Offset: 0x0085F0C4
		public int FindBoneIndex(string boneName)
		{
			if (boneName == null)
			{
				throw new ArgumentNullException("boneName", "boneName cannot be null.");
			}
			ExposedList<BoneData> exposedList = this.bones;
			BoneData[] items = exposedList.Items;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (items[i].name == boneName)
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		// Token: 0x0601B3F3 RID: 111603 RVA: 0x00860D24 File Offset: 0x0085F124
		public SlotData FindSlot(string slotName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<SlotData> exposedList = this.slots;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				SlotData slotData = exposedList.Items[i];
				if (slotData.name == slotName)
				{
					return slotData;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3F4 RID: 111604 RVA: 0x00860D84 File Offset: 0x0085F184
		public int FindSlotIndex(string slotName)
		{
			if (slotName == null)
			{
				throw new ArgumentNullException("slotName", "slotName cannot be null.");
			}
			ExposedList<SlotData> exposedList = this.slots;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (exposedList.Items[i].name == slotName)
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		// Token: 0x0601B3F5 RID: 111605 RVA: 0x00860DE4 File Offset: 0x0085F1E4
		public Skin FindSkin(string skinName)
		{
			if (skinName == null)
			{
				throw new ArgumentNullException("skinName", "skinName cannot be null.");
			}
			foreach (Skin skin in this.skins)
			{
				if (skin.name == skinName)
				{
					return skin;
				}
			}
			return null;
		}

		// Token: 0x0601B3F6 RID: 111606 RVA: 0x00860E6C File Offset: 0x0085F26C
		public EventData FindEvent(string eventDataName)
		{
			if (eventDataName == null)
			{
				throw new ArgumentNullException("eventDataName", "eventDataName cannot be null.");
			}
			foreach (EventData eventData in this.events)
			{
				if (eventData.name == eventDataName)
				{
					return eventData;
				}
			}
			return null;
		}

		// Token: 0x0601B3F7 RID: 111607 RVA: 0x00860EF4 File Offset: 0x0085F2F4
		public Animation FindAnimation(string animationName)
		{
			if (animationName == null)
			{
				throw new ArgumentNullException("animationName", "animationName cannot be null.");
			}
			ExposedList<Animation> exposedList = this.animations;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Animation animation = exposedList.Items[i];
				if (animation.name == animationName)
				{
					return animation;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3F8 RID: 111608 RVA: 0x00860F54 File Offset: 0x0085F354
		public IkConstraintData FindIkConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<IkConstraintData> exposedList = this.ikConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				IkConstraintData ikConstraintData = exposedList.Items[i];
				if (ikConstraintData.name == constraintName)
				{
					return ikConstraintData;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3F9 RID: 111609 RVA: 0x00860FB4 File Offset: 0x0085F3B4
		public TransformConstraintData FindTransformConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<TransformConstraintData> exposedList = this.transformConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				TransformConstraintData transformConstraintData = exposedList.Items[i];
				if (transformConstraintData.name == constraintName)
				{
					return transformConstraintData;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3FA RID: 111610 RVA: 0x00861014 File Offset: 0x0085F414
		public PathConstraintData FindPathConstraint(string constraintName)
		{
			if (constraintName == null)
			{
				throw new ArgumentNullException("constraintName", "constraintName cannot be null.");
			}
			ExposedList<PathConstraintData> exposedList = this.pathConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				PathConstraintData pathConstraintData = exposedList.Items[i];
				if (pathConstraintData.name.Equals(constraintName))
				{
					return pathConstraintData;
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3FB RID: 111611 RVA: 0x00861074 File Offset: 0x0085F474
		public int FindPathConstraintIndex(string pathConstraintName)
		{
			if (pathConstraintName == null)
			{
				throw new ArgumentNullException("pathConstraintName", "pathConstraintName cannot be null.");
			}
			ExposedList<PathConstraintData> exposedList = this.pathConstraints;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				if (exposedList.Items[i].name.Equals(pathConstraintName))
				{
					return i;
				}
				i++;
			}
			return -1;
		}

		// Token: 0x0601B3FC RID: 111612 RVA: 0x008610D2 File Offset: 0x0085F4D2
		public override string ToString()
		{
			return this.name ?? base.ToString();
		}

		// Token: 0x04012FBB RID: 77755
		internal string name;

		// Token: 0x04012FBC RID: 77756
		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		// Token: 0x04012FBD RID: 77757
		internal ExposedList<SlotData> slots = new ExposedList<SlotData>();

		// Token: 0x04012FBE RID: 77758
		internal ExposedList<Skin> skins = new ExposedList<Skin>();

		// Token: 0x04012FBF RID: 77759
		internal Skin defaultSkin;

		// Token: 0x04012FC0 RID: 77760
		internal ExposedList<EventData> events = new ExposedList<EventData>();

		// Token: 0x04012FC1 RID: 77761
		internal ExposedList<Animation> animations = new ExposedList<Animation>();

		// Token: 0x04012FC2 RID: 77762
		internal ExposedList<IkConstraintData> ikConstraints = new ExposedList<IkConstraintData>();

		// Token: 0x04012FC3 RID: 77763
		internal ExposedList<TransformConstraintData> transformConstraints = new ExposedList<TransformConstraintData>();

		// Token: 0x04012FC4 RID: 77764
		internal ExposedList<PathConstraintData> pathConstraints = new ExposedList<PathConstraintData>();

		// Token: 0x04012FC5 RID: 77765
		internal float width;

		// Token: 0x04012FC6 RID: 77766
		internal float height;

		// Token: 0x04012FC7 RID: 77767
		internal string version;

		// Token: 0x04012FC8 RID: 77768
		internal string hash;

		// Token: 0x04012FC9 RID: 77769
		internal float fps;

		// Token: 0x04012FCA RID: 77770
		internal string imagesPath;
	}
}
