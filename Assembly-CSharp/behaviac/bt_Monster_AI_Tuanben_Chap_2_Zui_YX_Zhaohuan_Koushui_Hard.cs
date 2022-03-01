using System;

namespace behaviac
{
	// Token: 0x020037F0 RID: 14320
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard
	{
		// Token: 0x060157D6 RID: 88022 RVA: 0x0067C6E0 File Offset: 0x0067AAE0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_YX_Zhaohuan_Koushui_Hard");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node4 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node4();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2 action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node2.HasEvents());
			Assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node1 assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node = new Assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node1();
			assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.SetId(1);
			sequence.AddChild(assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_Tuanben_Chap_2_Zui_YX_Zhaohuan_Koushui_Hard_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
