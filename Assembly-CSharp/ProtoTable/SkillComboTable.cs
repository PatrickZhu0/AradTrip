using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005BB RID: 1467
	public class SkillComboTable : IFlatbufferObject
	{
		// Token: 0x170014D3 RID: 5331
		// (get) Token: 0x06004C57 RID: 19543 RVA: 0x000EEDB0 File Offset: 0x000ED1B0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004C58 RID: 19544 RVA: 0x000EEDBD File Offset: 0x000ED1BD
		public static SkillComboTable GetRootAsSkillComboTable(ByteBuffer _bb)
		{
			return SkillComboTable.GetRootAsSkillComboTable(_bb, new SkillComboTable());
		}

		// Token: 0x06004C59 RID: 19545 RVA: 0x000EEDCA File Offset: 0x000ED1CA
		public static SkillComboTable GetRootAsSkillComboTable(ByteBuffer _bb, SkillComboTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004C5A RID: 19546 RVA: 0x000EEDE6 File Offset: 0x000ED1E6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004C5B RID: 19547 RVA: 0x000EEE00 File Offset: 0x000ED200
		public SkillComboTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170014D4 RID: 5332
		// (get) Token: 0x06004C5C RID: 19548 RVA: 0x000EEE0C File Offset: 0x000ED20C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014D5 RID: 5333
		// (get) Token: 0x06004C5D RID: 19549 RVA: 0x000EEE58 File Offset: 0x000ED258
		public int roomID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014D6 RID: 5334
		// (get) Token: 0x06004C5E RID: 19550 RVA: 0x000EEEA4 File Offset: 0x000ED2A4
		public int skillGroupID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014D7 RID: 5335
		// (get) Token: 0x06004C5F RID: 19551 RVA: 0x000EEEF0 File Offset: 0x000ED2F0
		public int skillID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014D8 RID: 5336
		// (get) Token: 0x06004C60 RID: 19552 RVA: 0x000EEF3C File Offset: 0x000ED33C
		public int skillLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014D9 RID: 5337
		// (get) Token: 0x06004C61 RID: 19553 RVA: 0x000EEF88 File Offset: 0x000ED388
		public int skillSlot
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014DA RID: 5338
		// (get) Token: 0x06004C62 RID: 19554 RVA: 0x000EEFD4 File Offset: 0x000ED3D4
		public string description
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C63 RID: 19555 RVA: 0x000EF017 File Offset: 0x000ED417
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170014DB RID: 5339
		// (get) Token: 0x06004C64 RID: 19556 RVA: 0x000EF028 File Offset: 0x000ED428
		public int skillTime
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014DC RID: 5340
		// (get) Token: 0x06004C65 RID: 19557 RVA: 0x000EF074 File Offset: 0x000ED474
		public int startDialogID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014DD RID: 5341
		// (get) Token: 0x06004C66 RID: 19558 RVA: 0x000EF0C0 File Offset: 0x000ED4C0
		public int endDialogID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014DE RID: 5342
		// (get) Token: 0x06004C67 RID: 19559 RVA: 0x000EF10C File Offset: 0x000ED50C
		public string guideTip
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C68 RID: 19560 RVA: 0x000EF14F File Offset: 0x000ED54F
		public ArraySegment<byte>? GetGuideTipBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170014DF RID: 5343
		// (get) Token: 0x06004C69 RID: 19561 RVA: 0x000EF160 File Offset: 0x000ED560
		public int joystick
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E0 RID: 5344
		// (get) Token: 0x06004C6A RID: 19562 RVA: 0x000EF1AC File Offset: 0x000ED5AC
		public int waitInputTime
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E1 RID: 5345
		// (get) Token: 0x06004C6B RID: 19563 RVA: 0x000EF1F8 File Offset: 0x000ED5F8
		public int moveDir
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E2 RID: 5346
		// (get) Token: 0x06004C6C RID: 19564 RVA: 0x000EF244 File Offset: 0x000ED644
		public int moveTime
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E3 RID: 5347
		// (get) Token: 0x06004C6D RID: 19565 RVA: 0x000EF290 File Offset: 0x000ED690
		public int idletime
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E4 RID: 5348
		// (get) Token: 0x06004C6E RID: 19566 RVA: 0x000EF2DC File Offset: 0x000ED6DC
		public int showUI
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E5 RID: 5349
		// (get) Token: 0x06004C6F RID: 19567 RVA: 0x000EF328 File Offset: 0x000ED728
		public int faceRight
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E6 RID: 5350
		// (get) Token: 0x06004C70 RID: 19568 RVA: 0x000EF374 File Offset: 0x000ED774
		public int sourceID
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014E7 RID: 5351
		// (get) Token: 0x06004C71 RID: 19569 RVA: 0x000EF3C0 File Offset: 0x000ED7C0
		public int phase
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-1949726329 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004C72 RID: 19570 RVA: 0x000EF40C File Offset: 0x000ED80C
		public static Offset<SkillComboTable> CreateSkillComboTable(FlatBufferBuilder builder, int ID = 0, int roomID = 0, int skillGroupID = 0, int skillID = 0, int skillLevel = 0, int skillSlot = 0, StringOffset descriptionOffset = default(StringOffset), int skillTime = 0, int startDialogID = 0, int endDialogID = 0, StringOffset guideTipOffset = default(StringOffset), int joystick = 0, int waitInputTime = 0, int moveDir = 0, int moveTime = 0, int idletime = 0, int showUI = 0, int faceRight = 0, int sourceID = 0, int phase = 0)
		{
			builder.StartObject(20);
			SkillComboTable.AddPhase(builder, phase);
			SkillComboTable.AddSourceID(builder, sourceID);
			SkillComboTable.AddFaceRight(builder, faceRight);
			SkillComboTable.AddShowUI(builder, showUI);
			SkillComboTable.AddIdletime(builder, idletime);
			SkillComboTable.AddMoveTime(builder, moveTime);
			SkillComboTable.AddMoveDir(builder, moveDir);
			SkillComboTable.AddWaitInputTime(builder, waitInputTime);
			SkillComboTable.AddJoystick(builder, joystick);
			SkillComboTable.AddGuideTip(builder, guideTipOffset);
			SkillComboTable.AddEndDialogID(builder, endDialogID);
			SkillComboTable.AddStartDialogID(builder, startDialogID);
			SkillComboTable.AddSkillTime(builder, skillTime);
			SkillComboTable.AddDescription(builder, descriptionOffset);
			SkillComboTable.AddSkillSlot(builder, skillSlot);
			SkillComboTable.AddSkillLevel(builder, skillLevel);
			SkillComboTable.AddSkillID(builder, skillID);
			SkillComboTable.AddSkillGroupID(builder, skillGroupID);
			SkillComboTable.AddRoomID(builder, roomID);
			SkillComboTable.AddID(builder, ID);
			return SkillComboTable.EndSkillComboTable(builder);
		}

		// Token: 0x06004C73 RID: 19571 RVA: 0x000EF4C4 File Offset: 0x000ED8C4
		public static void StartSkillComboTable(FlatBufferBuilder builder)
		{
			builder.StartObject(20);
		}

		// Token: 0x06004C74 RID: 19572 RVA: 0x000EF4CE File Offset: 0x000ED8CE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004C75 RID: 19573 RVA: 0x000EF4D9 File Offset: 0x000ED8D9
		public static void AddRoomID(FlatBufferBuilder builder, int roomID)
		{
			builder.AddInt(1, roomID, 0);
		}

		// Token: 0x06004C76 RID: 19574 RVA: 0x000EF4E4 File Offset: 0x000ED8E4
		public static void AddSkillGroupID(FlatBufferBuilder builder, int skillGroupID)
		{
			builder.AddInt(2, skillGroupID, 0);
		}

		// Token: 0x06004C77 RID: 19575 RVA: 0x000EF4EF File Offset: 0x000ED8EF
		public static void AddSkillID(FlatBufferBuilder builder, int skillID)
		{
			builder.AddInt(3, skillID, 0);
		}

		// Token: 0x06004C78 RID: 19576 RVA: 0x000EF4FA File Offset: 0x000ED8FA
		public static void AddSkillLevel(FlatBufferBuilder builder, int skillLevel)
		{
			builder.AddInt(4, skillLevel, 0);
		}

		// Token: 0x06004C79 RID: 19577 RVA: 0x000EF505 File Offset: 0x000ED905
		public static void AddSkillSlot(FlatBufferBuilder builder, int skillSlot)
		{
			builder.AddInt(5, skillSlot, 0);
		}

		// Token: 0x06004C7A RID: 19578 RVA: 0x000EF510 File Offset: 0x000ED910
		public static void AddDescription(FlatBufferBuilder builder, StringOffset descriptionOffset)
		{
			builder.AddOffset(6, descriptionOffset.Value, 0);
		}

		// Token: 0x06004C7B RID: 19579 RVA: 0x000EF521 File Offset: 0x000ED921
		public static void AddSkillTime(FlatBufferBuilder builder, int skillTime)
		{
			builder.AddInt(7, skillTime, 0);
		}

		// Token: 0x06004C7C RID: 19580 RVA: 0x000EF52C File Offset: 0x000ED92C
		public static void AddStartDialogID(FlatBufferBuilder builder, int startDialogID)
		{
			builder.AddInt(8, startDialogID, 0);
		}

		// Token: 0x06004C7D RID: 19581 RVA: 0x000EF537 File Offset: 0x000ED937
		public static void AddEndDialogID(FlatBufferBuilder builder, int endDialogID)
		{
			builder.AddInt(9, endDialogID, 0);
		}

		// Token: 0x06004C7E RID: 19582 RVA: 0x000EF543 File Offset: 0x000ED943
		public static void AddGuideTip(FlatBufferBuilder builder, StringOffset guideTipOffset)
		{
			builder.AddOffset(10, guideTipOffset.Value, 0);
		}

		// Token: 0x06004C7F RID: 19583 RVA: 0x000EF555 File Offset: 0x000ED955
		public static void AddJoystick(FlatBufferBuilder builder, int joystick)
		{
			builder.AddInt(11, joystick, 0);
		}

		// Token: 0x06004C80 RID: 19584 RVA: 0x000EF561 File Offset: 0x000ED961
		public static void AddWaitInputTime(FlatBufferBuilder builder, int waitInputTime)
		{
			builder.AddInt(12, waitInputTime, 0);
		}

		// Token: 0x06004C81 RID: 19585 RVA: 0x000EF56D File Offset: 0x000ED96D
		public static void AddMoveDir(FlatBufferBuilder builder, int moveDir)
		{
			builder.AddInt(13, moveDir, 0);
		}

		// Token: 0x06004C82 RID: 19586 RVA: 0x000EF579 File Offset: 0x000ED979
		public static void AddMoveTime(FlatBufferBuilder builder, int moveTime)
		{
			builder.AddInt(14, moveTime, 0);
		}

		// Token: 0x06004C83 RID: 19587 RVA: 0x000EF585 File Offset: 0x000ED985
		public static void AddIdletime(FlatBufferBuilder builder, int idletime)
		{
			builder.AddInt(15, idletime, 0);
		}

		// Token: 0x06004C84 RID: 19588 RVA: 0x000EF591 File Offset: 0x000ED991
		public static void AddShowUI(FlatBufferBuilder builder, int showUI)
		{
			builder.AddInt(16, showUI, 0);
		}

		// Token: 0x06004C85 RID: 19589 RVA: 0x000EF59D File Offset: 0x000ED99D
		public static void AddFaceRight(FlatBufferBuilder builder, int faceRight)
		{
			builder.AddInt(17, faceRight, 0);
		}

		// Token: 0x06004C86 RID: 19590 RVA: 0x000EF5A9 File Offset: 0x000ED9A9
		public static void AddSourceID(FlatBufferBuilder builder, int sourceID)
		{
			builder.AddInt(18, sourceID, 0);
		}

		// Token: 0x06004C87 RID: 19591 RVA: 0x000EF5B5 File Offset: 0x000ED9B5
		public static void AddPhase(FlatBufferBuilder builder, int phase)
		{
			builder.AddInt(19, phase, 0);
		}

		// Token: 0x06004C88 RID: 19592 RVA: 0x000EF5C4 File Offset: 0x000ED9C4
		public static Offset<SkillComboTable> EndSkillComboTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillComboTable>(value);
		}

		// Token: 0x06004C89 RID: 19593 RVA: 0x000EF5DE File Offset: 0x000ED9DE
		public static void FinishSkillComboTableBuffer(FlatBufferBuilder builder, Offset<SkillComboTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B80 RID: 7040
		private Table __p = new Table();

		// Token: 0x020005BC RID: 1468
		public enum eCrypt
		{
			// Token: 0x04001B82 RID: 7042
			code = -1949726329
		}
	}
}
