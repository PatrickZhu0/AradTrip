using System;

namespace behaviac
{
	// Token: 0x02002F2C RID: 12076
	public static class bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun
	{
		// Token: 0x0601472C RID: 83756 RVA: 0x00626DA4 File Offset: 0x006251A4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/7-4Dianti_zhaohuan/Dianti_chilun");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			sequence.AddChild(sequence2);
			Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2 condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node = new Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2();
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node.HasEvents());
			Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3 action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node = new Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3();
			action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node.SetClassNameString("Action");
			action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node.SetId(3);
			sequence2.AddChild(action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(4);
			sequence.AddChild(sequence3);
			Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node7 condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2 = new Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node7();
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2.SetId(7);
			sequence3.AddChild(condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2.HasEvents());
			Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node9 condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3 = new Condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node9();
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3.SetId(9);
			sequence3.AddChild(condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node3.HasEvents());
			Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node10 action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2 = new Action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node10();
			action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2.SetClassNameString("Action");
			action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2.SetId(10);
			sequence3.AddChild(action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_7_4Dianti_zhaohuan_Dianti_chilun_node2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
