using System;

namespace behaviac
{
	// Token: 0x02001D4C RID: 7500
	public static class bt_APC_APC_Gunman_test_DestinationSelect
	{
		// Token: 0x06012458 RID: 74840 RVA: 0x00554800 File Offset: 0x00552C00
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Gunman_test_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Gunman_test_DestinationSelect_node4 condition_bt_APC_APC_Gunman_test_DestinationSelect_node = new Condition_bt_APC_APC_Gunman_test_DestinationSelect_node4();
			condition_bt_APC_APC_Gunman_test_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Gunman_test_DestinationSelect_node.SetId(4);
			sequence.AddChild(condition_bt_APC_APC_Gunman_test_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Gunman_test_DestinationSelect_node.HasEvents());
			Action_bt_APC_APC_Gunman_test_DestinationSelect_node5 action_bt_APC_APC_Gunman_test_DestinationSelect_node = new Action_bt_APC_APC_Gunman_test_DestinationSelect_node5();
			action_bt_APC_APC_Gunman_test_DestinationSelect_node.SetClassNameString("Action");
			action_bt_APC_APC_Gunman_test_DestinationSelect_node.SetId(5);
			sequence.AddChild(action_bt_APC_APC_Gunman_test_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_APC_Gunman_test_DestinationSelect_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_APC_APC_Gunman_test_DestinationSelect_node6 condition_bt_APC_APC_Gunman_test_DestinationSelect_node2 = new Condition_bt_APC_APC_Gunman_test_DestinationSelect_node6();
			condition_bt_APC_APC_Gunman_test_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_APC_APC_Gunman_test_DestinationSelect_node2.SetId(6);
			sequence2.AddChild(condition_bt_APC_APC_Gunman_test_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Gunman_test_DestinationSelect_node2.HasEvents());
			Action_bt_APC_APC_Gunman_test_DestinationSelect_node7 action_bt_APC_APC_Gunman_test_DestinationSelect_node2 = new Action_bt_APC_APC_Gunman_test_DestinationSelect_node7();
			action_bt_APC_APC_Gunman_test_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_APC_APC_Gunman_test_DestinationSelect_node2.SetId(7);
			sequence2.AddChild(action_bt_APC_APC_Gunman_test_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Gunman_test_DestinationSelect_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Action_bt_APC_APC_Gunman_test_DestinationSelect_node3 action_bt_APC_APC_Gunman_test_DestinationSelect_node3 = new Action_bt_APC_APC_Gunman_test_DestinationSelect_node3();
			action_bt_APC_APC_Gunman_test_DestinationSelect_node3.SetClassNameString("Action");
			action_bt_APC_APC_Gunman_test_DestinationSelect_node3.SetId(3);
			selector.AddChild(action_bt_APC_APC_Gunman_test_DestinationSelect_node3);
			selector.SetHasEvents(selector.HasEvents() | action_bt_APC_APC_Gunman_test_DestinationSelect_node3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
