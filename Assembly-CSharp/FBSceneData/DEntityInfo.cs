using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B0B RID: 19211
	public sealed class DEntityInfo : Table
	{
		// Token: 0x0601BF32 RID: 114482 RVA: 0x0088D30D File Offset: 0x0088B70D
		public static DEntityInfo GetRootAsDEntityInfo(ByteBuffer _bb)
		{
			return DEntityInfo.GetRootAsDEntityInfo(_bb, new DEntityInfo());
		}

		// Token: 0x0601BF33 RID: 114483 RVA: 0x0088D31A File Offset: 0x0088B71A
		public static DEntityInfo GetRootAsDEntityInfo(ByteBuffer _bb, DEntityInfo obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BF34 RID: 114484 RVA: 0x0088D336 File Offset: 0x0088B736
		public DEntityInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002611 RID: 9745
		// (get) Token: 0x0601BF35 RID: 114485 RVA: 0x0088D348 File Offset: 0x0088B748
		public int Globalid
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002612 RID: 9746
		// (get) Token: 0x0601BF36 RID: 114486 RVA: 0x0088D37C File Offset: 0x0088B77C
		public int Resid
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002613 RID: 9747
		// (get) Token: 0x0601BF37 RID: 114487 RVA: 0x0088D3B0 File Offset: 0x0088B7B0
		public string Name
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002614 RID: 9748
		// (get) Token: 0x0601BF38 RID: 114488 RVA: 0x0088D3E0 File Offset: 0x0088B7E0
		public string Path
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002615 RID: 9749
		// (get) Token: 0x0601BF39 RID: 114489 RVA: 0x0088D410 File Offset: 0x0088B810
		public string Description
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002616 RID: 9750
		// (get) Token: 0x0601BF3A RID: 114490 RVA: 0x0088D440 File Offset: 0x0088B840
		public DEntityType Type
		{
			get
			{
				int num = base.__offset(14);
				return (DEntityType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x17002617 RID: 9751
		// (get) Token: 0x0601BF3B RID: 114491 RVA: 0x0088D478 File Offset: 0x0088B878
		public string TypeName
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002618 RID: 9752
		// (get) Token: 0x0601BF3C RID: 114492 RVA: 0x0088D4A8 File Offset: 0x0088B8A8
		public Vector3 Position
		{
			get
			{
				return this.GetPosition(new Vector3());
			}
		}

		// Token: 0x0601BF3D RID: 114493 RVA: 0x0088D4B8 File Offset: 0x0088B8B8
		public Vector3 GetPosition(Vector3 obj)
		{
			int num = base.__offset(18);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002619 RID: 9753
		// (get) Token: 0x0601BF3E RID: 114494 RVA: 0x0088D4F0 File Offset: 0x0088B8F0
		public float Scale
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 1f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700261A RID: 9754
		// (get) Token: 0x0601BF3F RID: 114495 RVA: 0x0088D529 File Offset: 0x0088B929
		public Color Color
		{
			get
			{
				return this.GetColor(new Color());
			}
		}

		// Token: 0x0601BF40 RID: 114496 RVA: 0x0088D538 File Offset: 0x0088B938
		public Color GetColor(Color obj)
		{
			int num = base.__offset(22);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601BF41 RID: 114497 RVA: 0x0088D56E File Offset: 0x0088B96E
		public static void StartDEntityInfo(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0601BF42 RID: 114498 RVA: 0x0088D578 File Offset: 0x0088B978
		public static void AddGlobalid(FlatBufferBuilder builder, int globalid)
		{
			builder.AddInt(0, globalid, 0);
		}

		// Token: 0x0601BF43 RID: 114499 RVA: 0x0088D583 File Offset: 0x0088B983
		public static void AddResid(FlatBufferBuilder builder, int resid)
		{
			builder.AddInt(1, resid, 0);
		}

		// Token: 0x0601BF44 RID: 114500 RVA: 0x0088D58E File Offset: 0x0088B98E
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(2, nameOffset.Value, 0);
		}

		// Token: 0x0601BF45 RID: 114501 RVA: 0x0088D59F File Offset: 0x0088B99F
		public static void AddPath(FlatBufferBuilder builder, StringOffset pathOffset)
		{
			builder.AddOffset(3, pathOffset.Value, 0);
		}

		// Token: 0x0601BF46 RID: 114502 RVA: 0x0088D5B0 File Offset: 0x0088B9B0
		public static void AddDescription(FlatBufferBuilder builder, StringOffset descriptionOffset)
		{
			builder.AddOffset(4, descriptionOffset.Value, 0);
		}

		// Token: 0x0601BF47 RID: 114503 RVA: 0x0088D5C1 File Offset: 0x0088B9C1
		public static void AddType(FlatBufferBuilder builder, DEntityType type)
		{
			builder.AddSbyte(5, (sbyte)type, 0);
		}

		// Token: 0x0601BF48 RID: 114504 RVA: 0x0088D5CC File Offset: 0x0088B9CC
		public static void AddTypeName(FlatBufferBuilder builder, StringOffset typeNameOffset)
		{
			builder.AddOffset(6, typeNameOffset.Value, 0);
		}

		// Token: 0x0601BF49 RID: 114505 RVA: 0x0088D5DD File Offset: 0x0088B9DD
		public static void AddPosition(FlatBufferBuilder builder, Offset<Vector3> positionOffset)
		{
			builder.AddStruct(7, positionOffset.Value, 0);
		}

		// Token: 0x0601BF4A RID: 114506 RVA: 0x0088D5EE File Offset: 0x0088B9EE
		public static void AddScale(FlatBufferBuilder builder, float scale)
		{
			builder.AddFloat(8, scale, 1.0);
		}

		// Token: 0x0601BF4B RID: 114507 RVA: 0x0088D601 File Offset: 0x0088BA01
		public static void AddColor(FlatBufferBuilder builder, Offset<Color> colorOffset)
		{
			builder.AddStruct(9, colorOffset.Value, 0);
		}

		// Token: 0x0601BF4C RID: 114508 RVA: 0x0088D614 File Offset: 0x0088BA14
		public static Offset<DEntityInfo> EndDEntityInfo(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DEntityInfo>(value);
		}
	}
}
