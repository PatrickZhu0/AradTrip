using System;

namespace behaviac
{
	// Token: 0x02002F2F RID: 12079
	public static class bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan
	{
		// Token: 0x06014731 RID: 83761 RVA: 0x0062707C File Offset: 0x0062547C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/7-4Dianti_zhaohuan/Dianti_zhaohuan");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			sequence.AddChild(sequence2);
			Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node0 condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node = new Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node0();
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node.SetId(0);
			sequence2.AddChild(condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node.HasEvents());
			Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node3 action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node = new Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node3();
			action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node.SetClassNameString("Action");
			action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node.SetId(3);
			sequence2.AddChild(action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_zhaohuan_node.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
