using System;

namespace behaviac
{
	// Token: 0x020037BB RID: 14267
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou
	{
		// Token: 0x06015778 RID: 87928 RVA: 0x0067AAD4 File Offset: 0x00678ED4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_Jishengshou");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node1 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node1();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node5 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node5();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node6 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node6();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_node3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
