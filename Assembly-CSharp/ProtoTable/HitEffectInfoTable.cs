using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000490 RID: 1168
	public class HitEffectInfoTable : IFlatbufferObject
	{
		// Token: 0x17000E53 RID: 3667
		// (get) Token: 0x060038BA RID: 14522 RVA: 0x000C0C50 File Offset: 0x000BF050
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060038BB RID: 14523 RVA: 0x000C0C5D File Offset: 0x000BF05D
		public static HitEffectInfoTable GetRootAsHitEffectInfoTable(ByteBuffer _bb)
		{
			return HitEffectInfoTable.GetRootAsHitEffectInfoTable(_bb, new HitEffectInfoTable());
		}

		// Token: 0x060038BC RID: 14524 RVA: 0x000C0C6A File Offset: 0x000BF06A
		public static HitEffectInfoTable GetRootAsHitEffectInfoTable(ByteBuffer _bb, HitEffectInfoTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060038BD RID: 14525 RVA: 0x000C0C86 File Offset: 0x000BF086
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060038BE RID: 14526 RVA: 0x000C0CA0 File Offset: 0x000BF0A0
		public HitEffectInfoTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E54 RID: 3668
		// (get) Token: 0x060038BF RID: 14527 RVA: 0x000C0CAC File Offset: 0x000BF0AC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E55 RID: 3669
		// (get) Token: 0x060038C0 RID: 14528 RVA: 0x000C0CF8 File Offset: 0x000BF0F8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060038C1 RID: 14529 RVA: 0x000C0D3A File Offset: 0x000BF13A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000E56 RID: 3670
		// (get) Token: 0x060038C2 RID: 14530 RVA: 0x000C0D48 File Offset: 0x000BF148
		public bool Mirror
		{
			get
			{
				int num = this.__p.__offset(8);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060038C3 RID: 14531 RVA: 0x000C0D94 File Offset: 0x000BF194
		public int OffsetXArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E57 RID: 3671
		// (get) Token: 0x060038C4 RID: 14532 RVA: 0x000C0DE4 File Offset: 0x000BF1E4
		public int OffsetXLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060038C5 RID: 14533 RVA: 0x000C0E17 File Offset: 0x000BF217
		public ArraySegment<byte>? GetOffsetXBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000E58 RID: 3672
		// (get) Token: 0x060038C6 RID: 14534 RVA: 0x000C0E26 File Offset: 0x000BF226
		public FlatBufferArray<int> OffsetX
		{
			get
			{
				if (this.OffsetXValue == null)
				{
					this.OffsetXValue = new FlatBufferArray<int>(new Func<int, int>(this.OffsetXArray), this.OffsetXLength);
				}
				return this.OffsetXValue;
			}
		}

		// Token: 0x060038C7 RID: 14535 RVA: 0x000C0E58 File Offset: 0x000BF258
		public int OffsetYArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E59 RID: 3673
		// (get) Token: 0x060038C8 RID: 14536 RVA: 0x000C0EA8 File Offset: 0x000BF2A8
		public int OffsetYLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060038C9 RID: 14537 RVA: 0x000C0EDB File Offset: 0x000BF2DB
		public ArraySegment<byte>? GetOffsetYBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000E5A RID: 3674
		// (get) Token: 0x060038CA RID: 14538 RVA: 0x000C0EEA File Offset: 0x000BF2EA
		public FlatBufferArray<int> OffsetY
		{
			get
			{
				if (this.OffsetYValue == null)
				{
					this.OffsetYValue = new FlatBufferArray<int>(new Func<int, int>(this.OffsetYArray), this.OffsetYLength);
				}
				return this.OffsetYValue;
			}
		}

		// Token: 0x060038CB RID: 14539 RVA: 0x000C0F1C File Offset: 0x000BF31C
		public int RotateXArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E5B RID: 3675
		// (get) Token: 0x060038CC RID: 14540 RVA: 0x000C0F6C File Offset: 0x000BF36C
		public int RotateXLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060038CD RID: 14541 RVA: 0x000C0F9F File Offset: 0x000BF39F
		public ArraySegment<byte>? GetRotateXBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000E5C RID: 3676
		// (get) Token: 0x060038CE RID: 14542 RVA: 0x000C0FAE File Offset: 0x000BF3AE
		public FlatBufferArray<int> RotateX
		{
			get
			{
				if (this.RotateXValue == null)
				{
					this.RotateXValue = new FlatBufferArray<int>(new Func<int, int>(this.RotateXArray), this.RotateXLength);
				}
				return this.RotateXValue;
			}
		}

		// Token: 0x060038CF RID: 14543 RVA: 0x000C0FE0 File Offset: 0x000BF3E0
		public int RotateYArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E5D RID: 3677
		// (get) Token: 0x060038D0 RID: 14544 RVA: 0x000C1030 File Offset: 0x000BF430
		public int RotateYLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060038D1 RID: 14545 RVA: 0x000C1063 File Offset: 0x000BF463
		public ArraySegment<byte>? GetRotateYBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000E5E RID: 3678
		// (get) Token: 0x060038D2 RID: 14546 RVA: 0x000C1072 File Offset: 0x000BF472
		public FlatBufferArray<int> RotateY
		{
			get
			{
				if (this.RotateYValue == null)
				{
					this.RotateYValue = new FlatBufferArray<int>(new Func<int, int>(this.RotateYArray), this.RotateYLength);
				}
				return this.RotateYValue;
			}
		}

		// Token: 0x060038D3 RID: 14547 RVA: 0x000C10A4 File Offset: 0x000BF4A4
		public int RotateZArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E5F RID: 3679
		// (get) Token: 0x060038D4 RID: 14548 RVA: 0x000C10F4 File Offset: 0x000BF4F4
		public int RotateZLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060038D5 RID: 14549 RVA: 0x000C1127 File Offset: 0x000BF527
		public ArraySegment<byte>? GetRotateZBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000E60 RID: 3680
		// (get) Token: 0x060038D6 RID: 14550 RVA: 0x000C1136 File Offset: 0x000BF536
		public FlatBufferArray<int> RotateZ
		{
			get
			{
				if (this.RotateZValue == null)
				{
					this.RotateZValue = new FlatBufferArray<int>(new Func<int, int>(this.RotateZArray), this.RotateZLength);
				}
				return this.RotateZValue;
			}
		}

		// Token: 0x060038D7 RID: 14551 RVA: 0x000C1168 File Offset: 0x000BF568
		public int ScaleArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000E61 RID: 3681
		// (get) Token: 0x060038D8 RID: 14552 RVA: 0x000C11B8 File Offset: 0x000BF5B8
		public int ScaleLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060038D9 RID: 14553 RVA: 0x000C11EB File Offset: 0x000BF5EB
		public ArraySegment<byte>? GetScaleBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000E62 RID: 3682
		// (get) Token: 0x060038DA RID: 14554 RVA: 0x000C11FA File Offset: 0x000BF5FA
		public FlatBufferArray<int> Scale
		{
			get
			{
				if (this.ScaleValue == null)
				{
					this.ScaleValue = new FlatBufferArray<int>(new Func<int, int>(this.ScaleArray), this.ScaleLength);
				}
				return this.ScaleValue;
			}
		}

		// Token: 0x17000E63 RID: 3683
		// (get) Token: 0x060038DB RID: 14555 RVA: 0x000C122C File Offset: 0x000BF62C
		public int Type
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E64 RID: 3684
		// (get) Token: 0x060038DC RID: 14556 RVA: 0x000C1278 File Offset: 0x000BF678
		public int Loop
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-727248362 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060038DD RID: 14557 RVA: 0x000C12C4 File Offset: 0x000BF6C4
		public static Offset<HitEffectInfoTable> CreateHitEffectInfoTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), bool Mirror = false, VectorOffset OffsetXOffset = default(VectorOffset), VectorOffset OffsetYOffset = default(VectorOffset), VectorOffset RotateXOffset = default(VectorOffset), VectorOffset RotateYOffset = default(VectorOffset), VectorOffset RotateZOffset = default(VectorOffset), VectorOffset ScaleOffset = default(VectorOffset), int Type = 0, int Loop = 0)
		{
			builder.StartObject(11);
			HitEffectInfoTable.AddLoop(builder, Loop);
			HitEffectInfoTable.AddType(builder, Type);
			HitEffectInfoTable.AddScale(builder, ScaleOffset);
			HitEffectInfoTable.AddRotateZ(builder, RotateZOffset);
			HitEffectInfoTable.AddRotateY(builder, RotateYOffset);
			HitEffectInfoTable.AddRotateX(builder, RotateXOffset);
			HitEffectInfoTable.AddOffsetY(builder, OffsetYOffset);
			HitEffectInfoTable.AddOffsetX(builder, OffsetXOffset);
			HitEffectInfoTable.AddName(builder, NameOffset);
			HitEffectInfoTable.AddID(builder, ID);
			HitEffectInfoTable.AddMirror(builder, Mirror);
			return HitEffectInfoTable.EndHitEffectInfoTable(builder);
		}

		// Token: 0x060038DE RID: 14558 RVA: 0x000C1334 File Offset: 0x000BF734
		public static void StartHitEffectInfoTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x060038DF RID: 14559 RVA: 0x000C133E File Offset: 0x000BF73E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060038E0 RID: 14560 RVA: 0x000C1349 File Offset: 0x000BF749
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060038E1 RID: 14561 RVA: 0x000C135A File Offset: 0x000BF75A
		public static void AddMirror(FlatBufferBuilder builder, bool Mirror)
		{
			builder.AddBool(2, Mirror, false);
		}

		// Token: 0x060038E2 RID: 14562 RVA: 0x000C1365 File Offset: 0x000BF765
		public static void AddOffsetX(FlatBufferBuilder builder, VectorOffset OffsetXOffset)
		{
			builder.AddOffset(3, OffsetXOffset.Value, 0);
		}

		// Token: 0x060038E3 RID: 14563 RVA: 0x000C1378 File Offset: 0x000BF778
		public static VectorOffset CreateOffsetXVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060038E4 RID: 14564 RVA: 0x000C13B5 File Offset: 0x000BF7B5
		public static void StartOffsetXVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060038E5 RID: 14565 RVA: 0x000C13C0 File Offset: 0x000BF7C0
		public static void AddOffsetY(FlatBufferBuilder builder, VectorOffset OffsetYOffset)
		{
			builder.AddOffset(4, OffsetYOffset.Value, 0);
		}

		// Token: 0x060038E6 RID: 14566 RVA: 0x000C13D4 File Offset: 0x000BF7D4
		public static VectorOffset CreateOffsetYVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060038E7 RID: 14567 RVA: 0x000C1411 File Offset: 0x000BF811
		public static void StartOffsetYVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060038E8 RID: 14568 RVA: 0x000C141C File Offset: 0x000BF81C
		public static void AddRotateX(FlatBufferBuilder builder, VectorOffset RotateXOffset)
		{
			builder.AddOffset(5, RotateXOffset.Value, 0);
		}

		// Token: 0x060038E9 RID: 14569 RVA: 0x000C1430 File Offset: 0x000BF830
		public static VectorOffset CreateRotateXVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060038EA RID: 14570 RVA: 0x000C146D File Offset: 0x000BF86D
		public static void StartRotateXVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060038EB RID: 14571 RVA: 0x000C1478 File Offset: 0x000BF878
		public static void AddRotateY(FlatBufferBuilder builder, VectorOffset RotateYOffset)
		{
			builder.AddOffset(6, RotateYOffset.Value, 0);
		}

		// Token: 0x060038EC RID: 14572 RVA: 0x000C148C File Offset: 0x000BF88C
		public static VectorOffset CreateRotateYVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060038ED RID: 14573 RVA: 0x000C14C9 File Offset: 0x000BF8C9
		public static void StartRotateYVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060038EE RID: 14574 RVA: 0x000C14D4 File Offset: 0x000BF8D4
		public static void AddRotateZ(FlatBufferBuilder builder, VectorOffset RotateZOffset)
		{
			builder.AddOffset(7, RotateZOffset.Value, 0);
		}

		// Token: 0x060038EF RID: 14575 RVA: 0x000C14E8 File Offset: 0x000BF8E8
		public static VectorOffset CreateRotateZVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060038F0 RID: 14576 RVA: 0x000C1525 File Offset: 0x000BF925
		public static void StartRotateZVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060038F1 RID: 14577 RVA: 0x000C1530 File Offset: 0x000BF930
		public static void AddScale(FlatBufferBuilder builder, VectorOffset ScaleOffset)
		{
			builder.AddOffset(8, ScaleOffset.Value, 0);
		}

		// Token: 0x060038F2 RID: 14578 RVA: 0x000C1544 File Offset: 0x000BF944
		public static VectorOffset CreateScaleVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060038F3 RID: 14579 RVA: 0x000C1581 File Offset: 0x000BF981
		public static void StartScaleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060038F4 RID: 14580 RVA: 0x000C158C File Offset: 0x000BF98C
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(9, Type, 0);
		}

		// Token: 0x060038F5 RID: 14581 RVA: 0x000C1598 File Offset: 0x000BF998
		public static void AddLoop(FlatBufferBuilder builder, int Loop)
		{
			builder.AddInt(10, Loop, 0);
		}

		// Token: 0x060038F6 RID: 14582 RVA: 0x000C15A4 File Offset: 0x000BF9A4
		public static Offset<HitEffectInfoTable> EndHitEffectInfoTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HitEffectInfoTable>(value);
		}

		// Token: 0x060038F7 RID: 14583 RVA: 0x000C15BE File Offset: 0x000BF9BE
		public static void FinishHitEffectInfoTableBuffer(FlatBufferBuilder builder, Offset<HitEffectInfoTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400160F RID: 5647
		private Table __p = new Table();

		// Token: 0x04001610 RID: 5648
		private FlatBufferArray<int> OffsetXValue;

		// Token: 0x04001611 RID: 5649
		private FlatBufferArray<int> OffsetYValue;

		// Token: 0x04001612 RID: 5650
		private FlatBufferArray<int> RotateXValue;

		// Token: 0x04001613 RID: 5651
		private FlatBufferArray<int> RotateYValue;

		// Token: 0x04001614 RID: 5652
		private FlatBufferArray<int> RotateZValue;

		// Token: 0x04001615 RID: 5653
		private FlatBufferArray<int> ScaleValue;

		// Token: 0x02000491 RID: 1169
		public enum eCrypt
		{
			// Token: 0x04001617 RID: 5655
			code = -727248362
		}
	}
}
