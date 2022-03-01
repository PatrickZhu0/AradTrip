using System;

namespace behaviac
{
	// Token: 0x02001D46 RID: 7494
	public static class bt_APC_APC_Gunman_test_Action
	{
		// Token: 0x0601244D RID: 74829 RVA: 0x00554458 File Offset: 0x00552858
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Gunman_test_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Gunman_test_Action_node2 condition_bt_APC_APC_Gunman_test_Action_node = new Condition_bt_APC_APC_Gunman_test_Action_node2();
			condition_bt_APC_APC_Gunman_test_Action_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Gunman_test_Action_node.SetId(2);
			sequence.AddChild(condition_bt_APC_APC_Gunman_test_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Gunman_test_Action_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			sequence.AddChild(sequence2);
			Action_bt_APC_APC_Gunman_test_Action_node4 action_bt_APC_APC_Gunman_test_Action_node = new Action_bt_APC_APC_Gunman_test_Action_node4();
			action_bt_APC_APC_Gunman_test_Action_node.SetClassNameString("Action");
			action_bt_APC_APC_Gunman_test_Action_node.SetId(4);
			sequence2.AddChild(action_bt_APC_APC_Gunman_test_Action_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Gunman_test_Action_node.HasEvents());
			Action_bt_APC_APC_Gunman_test_Action_node5 action_bt_APC_APC_Gunman_test_Action_node2 = new Action_bt_APC_APC_Gunman_test_Action_node5();
			action_bt_APC_APC_Gunman_test_Action_node2.SetClassNameString("Action");
			action_bt_APC_APC_Gunman_test_Action_node2.SetId(5);
			sequence2.AddChild(action_bt_APC_APC_Gunman_test_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Gunman_test_Action_node2.HasEvents());
			Action_bt_APC_APC_Gunman_test_Action_node6 action_bt_APC_APC_Gunman_test_Action_node3 = new Action_bt_APC_APC_Gunman_test_Action_node6();
			action_bt_APC_APC_Gunman_test_Action_node3.SetClassNameString("Action");
			action_bt_APC_APC_Gunman_test_Action_node3.SetId(6);
			sequence2.AddChild(action_bt_APC_APC_Gunman_test_Action_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Gunman_test_Action_node3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(7);
			selector.AddChild(sequence3);
			Condition_bt_APC_APC_Gunman_test_Action_node8 condition_bt_APC_APC_Gunman_test_Action_node2 = new Condition_bt_APC_APC_Gunman_test_Action_node8();
			condition_bt_APC_APC_Gunman_test_Action_node2.SetClassNameString("Condition");
			condition_bt_APC_APC_Gunman_test_Action_node2.SetId(8);
			sequence3.AddChild(condition_bt_APC_APC_Gunman_test_Action_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Gunman_test_Action_node2.HasEvents());
			Condition_bt_APC_APC_Gunman_test_Action_node9 condition_bt_APC_APC_Gunman_test_Action_node3 = new Condition_bt_APC_APC_Gunman_test_Action_node9();
			condition_bt_APC_APC_Gunman_test_Action_node3.SetClassNameString("Condition");
			condition_bt_APC_APC_Gunman_test_Action_node3.SetId(9);
			sequence3.AddChild(condition_bt_APC_APC_Gunman_test_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Gunman_test_Action_node3.HasEvents());
			Action_bt_APC_APC_Gunman_test_Action_node10 action_bt_APC_APC_Gunman_test_Action_node4 = new Action_bt_APC_APC_Gunman_test_Action_node10();
			action_bt_APC_APC_Gunman_test_Action_node4.SetClassNameString("Action");
			action_bt_APC_APC_Gunman_test_Action_node4.SetId(10);
			sequence3.AddChild(action_bt_APC_APC_Gunman_test_Action_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_APC_APC_Gunman_test_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
