using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005CB RID: 1483
	public class SoundTable : IFlatbufferObject
	{
		// Token: 0x170015AD RID: 5549
		// (get) Token: 0x06004EC4 RID: 20164 RVA: 0x000F51CC File Offset: 0x000F35CC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004EC5 RID: 20165 RVA: 0x000F51D9 File Offset: 0x000F35D9
		public static SoundTable GetRootAsSoundTable(ByteBuffer _bb)
		{
			return SoundTable.GetRootAsSoundTable(_bb, new SoundTable());
		}

		// Token: 0x06004EC6 RID: 20166 RVA: 0x000F51E6 File Offset: 0x000F35E6
		public static SoundTable GetRootAsSoundTable(ByteBuffer _bb, SoundTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004EC7 RID: 20167 RVA: 0x000F5202 File Offset: 0x000F3602
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004EC8 RID: 20168 RVA: 0x000F521C File Offset: 0x000F361C
		public SoundTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015AE RID: 5550
		// (get) Token: 0x06004EC9 RID: 20169 RVA: 0x000F5228 File Offset: 0x000F3628
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1302576307 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015AF RID: 5551
		// (get) Token: 0x06004ECA RID: 20170 RVA: 0x000F5274 File Offset: 0x000F3674
		public string Descrip
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004ECB RID: 20171 RVA: 0x000F52B6 File Offset: 0x000F36B6
		public ArraySegment<byte>? GetDescripBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06004ECC RID: 20172 RVA: 0x000F52C4 File Offset: 0x000F36C4
		public string PathArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170015B0 RID: 5552
		// (get) Token: 0x06004ECD RID: 20173 RVA: 0x000F530C File Offset: 0x000F370C
		public int PathLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170015B1 RID: 5553
		// (get) Token: 0x06004ECE RID: 20174 RVA: 0x000F533E File Offset: 0x000F373E
		public FlatBufferArray<string> Path
		{
			get
			{
				if (this.PathValue == null)
				{
					this.PathValue = new FlatBufferArray<string>(new Func<int, string>(this.PathArray), this.PathLength);
				}
				return this.PathValue;
			}
		}

		// Token: 0x170015B2 RID: 5554
		// (get) Token: 0x06004ECF RID: 20175 RVA: 0x000F5370 File Offset: 0x000F3770
		public int Loop
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1302576307 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015B3 RID: 5555
		// (get) Token: 0x06004ED0 RID: 20176 RVA: 0x000F53BC File Offset: 0x000F37BC
		public int IsRandom
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1302576307 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015B4 RID: 5556
		// (get) Token: 0x06004ED1 RID: 20177 RVA: 0x000F5408 File Offset: 0x000F3808
		public int Type
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1302576307 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004ED2 RID: 20178 RVA: 0x000F5452 File Offset: 0x000F3852
		public static Offset<SoundTable> CreateSoundTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescripOffset = default(StringOffset), VectorOffset PathOffset = default(VectorOffset), int Loop = 0, int IsRandom = 0, int Type = 0)
		{
			builder.StartObject(6);
			SoundTable.AddType(builder, Type);
			SoundTable.AddIsRandom(builder, IsRandom);
			SoundTable.AddLoop(builder, Loop);
			SoundTable.AddPath(builder, PathOffset);
			SoundTable.AddDescrip(builder, DescripOffset);
			SoundTable.AddID(builder, ID);
			return SoundTable.EndSoundTable(builder);
		}

		// Token: 0x06004ED3 RID: 20179 RVA: 0x000F548E File Offset: 0x000F388E
		public static void StartSoundTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06004ED4 RID: 20180 RVA: 0x000F5497 File Offset: 0x000F3897
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004ED5 RID: 20181 RVA: 0x000F54A2 File Offset: 0x000F38A2
		public static void AddDescrip(FlatBufferBuilder builder, StringOffset DescripOffset)
		{
			builder.AddOffset(1, DescripOffset.Value, 0);
		}

		// Token: 0x06004ED6 RID: 20182 RVA: 0x000F54B3 File Offset: 0x000F38B3
		public static void AddPath(FlatBufferBuilder builder, VectorOffset PathOffset)
		{
			builder.AddOffset(2, PathOffset.Value, 0);
		}

		// Token: 0x06004ED7 RID: 20183 RVA: 0x000F54C4 File Offset: 0x000F38C4
		public static VectorOffset CreatePathVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004ED8 RID: 20184 RVA: 0x000F550A File Offset: 0x000F390A
		public static void StartPathVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004ED9 RID: 20185 RVA: 0x000F5515 File Offset: 0x000F3915
		public static void AddLoop(FlatBufferBuilder builder, int Loop)
		{
			builder.AddInt(3, Loop, 0);
		}

		// Token: 0x06004EDA RID: 20186 RVA: 0x000F5520 File Offset: 0x000F3920
		public static void AddIsRandom(FlatBufferBuilder builder, int IsRandom)
		{
			builder.AddInt(4, IsRandom, 0);
		}

		// Token: 0x06004EDB RID: 20187 RVA: 0x000F552B File Offset: 0x000F392B
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(5, Type, 0);
		}

		// Token: 0x06004EDC RID: 20188 RVA: 0x000F5538 File Offset: 0x000F3938
		public static Offset<SoundTable> EndSoundTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SoundTable>(value);
		}

		// Token: 0x06004EDD RID: 20189 RVA: 0x000F5552 File Offset: 0x000F3952
		public static void FinishSoundTableBuffer(FlatBufferBuilder builder, Offset<SoundTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BD1 RID: 7121
		private Table __p = new Table();

		// Token: 0x04001BD2 RID: 7122
		private FlatBufferArray<string> PathValue;

		// Token: 0x020005CC RID: 1484
		public enum eCrypt
		{
			// Token: 0x04001BD4 RID: 7124
			code = -1302576307
		}
	}
}
