using System;

namespace behaviac
{
	// Token: 0x02003809 RID: 14345
	public static class bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2
	{
		// Token: 0x06015803 RID: 88067 RVA: 0x0067D204 File Offset: 0x0067B604
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_2_Zui_Zui_2");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node0 parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node = new Parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node0();
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetId(0);
			bt.AddChild(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node6 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node6();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node10 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node10();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node2.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5 condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3 = new Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5();
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node9 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node9();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3.SetId(9);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node8 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node8();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4.SetId(8);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node11 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node11();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node5.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node7 action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node6 = new Action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node7();
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node6.SetId(7);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node6.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Tuanben_Chap_2_Zui_Zui_2_node.HasEvents());
			return true;
		}
	}
}
