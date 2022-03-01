using System;

namespace behaviac
{
	// Token: 0x020037C0 RID: 14272
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1
	{
		// Token: 0x06015781 RID: 87937 RVA: 0x0067ADC0 File Offset: 0x006791C0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_Jishengshou_1");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(8);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node1 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node1();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node10 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node10();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node11 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node11();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_1_node3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
