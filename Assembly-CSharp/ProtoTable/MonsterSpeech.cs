using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200051C RID: 1308
	public class MonsterSpeech : IFlatbufferObject
	{
		// Token: 0x170011E9 RID: 4585
		// (get) Token: 0x06004344 RID: 17220 RVA: 0x000DA404 File Offset: 0x000D8804
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004345 RID: 17221 RVA: 0x000DA411 File Offset: 0x000D8811
		public static MonsterSpeech GetRootAsMonsterSpeech(ByteBuffer _bb)
		{
			return MonsterSpeech.GetRootAsMonsterSpeech(_bb, new MonsterSpeech());
		}

		// Token: 0x06004346 RID: 17222 RVA: 0x000DA41E File Offset: 0x000D881E
		public static MonsterSpeech GetRootAsMonsterSpeech(ByteBuffer _bb, MonsterSpeech obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004347 RID: 17223 RVA: 0x000DA43A File Offset: 0x000D883A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004348 RID: 17224 RVA: 0x000DA454 File Offset: 0x000D8854
		public MonsterSpeech __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011EA RID: 4586
		// (get) Token: 0x06004349 RID: 17225 RVA: 0x000DA460 File Offset: 0x000D8860
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1217104176 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011EB RID: 4587
		// (get) Token: 0x0600434A RID: 17226 RVA: 0x000DA4AC File Offset: 0x000D88AC
		public string Speech
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600434B RID: 17227 RVA: 0x000DA4EE File Offset: 0x000D88EE
		public ArraySegment<byte>? GetSpeechBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x0600434C RID: 17228 RVA: 0x000DA4FC File Offset: 0x000D88FC
		public static Offset<MonsterSpeech> CreateMonsterSpeech(FlatBufferBuilder builder, int ID = 0, StringOffset SpeechOffset = default(StringOffset))
		{
			builder.StartObject(2);
			MonsterSpeech.AddSpeech(builder, SpeechOffset);
			MonsterSpeech.AddID(builder, ID);
			return MonsterSpeech.EndMonsterSpeech(builder);
		}

		// Token: 0x0600434D RID: 17229 RVA: 0x000DA519 File Offset: 0x000D8919
		public static void StartMonsterSpeech(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0600434E RID: 17230 RVA: 0x000DA522 File Offset: 0x000D8922
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600434F RID: 17231 RVA: 0x000DA52D File Offset: 0x000D892D
		public static void AddSpeech(FlatBufferBuilder builder, StringOffset SpeechOffset)
		{
			builder.AddOffset(1, SpeechOffset.Value, 0);
		}

		// Token: 0x06004350 RID: 17232 RVA: 0x000DA540 File Offset: 0x000D8940
		public static Offset<MonsterSpeech> EndMonsterSpeech(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonsterSpeech>(value);
		}

		// Token: 0x06004351 RID: 17233 RVA: 0x000DA55A File Offset: 0x000D895A
		public static void FinishMonsterSpeechBuffer(FlatBufferBuilder builder, Offset<MonsterSpeech> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018E7 RID: 6375
		private Table __p = new Table();

		// Token: 0x0200051D RID: 1309
		public enum eCrypt
		{
			// Token: 0x040018E9 RID: 6377
			code = 1217104176
		}
	}
}
