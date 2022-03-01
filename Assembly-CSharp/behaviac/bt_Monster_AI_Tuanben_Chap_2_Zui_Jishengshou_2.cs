using System;

namespace behaviac
{
	// Token: 0x020037C7 RID: 14279
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2
	{
		// Token: 0x0601578E RID: 87950 RVA: 0x0067B108 File Offset: 0x00679508
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_Jishengshou_2");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node7 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node7();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node6 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node6();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node4 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node2();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node4.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node1 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node1();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Jishengshou_2_node5.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
