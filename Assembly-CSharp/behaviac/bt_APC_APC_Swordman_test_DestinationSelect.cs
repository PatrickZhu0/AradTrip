using System;

namespace behaviac
{
	// Token: 0x02001E12 RID: 7698
	public static class bt_APC_APC_Swordman_test_DestinationSelect
	{
		// Token: 0x060125D6 RID: 75222 RVA: 0x0055D5D4 File Offset: 0x0055B9D4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Swordman_test_DestinationSelect");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Swordman_test_DestinationSelect_node2 condition_bt_APC_APC_Swordman_test_DestinationSelect_node = new Condition_bt_APC_APC_Swordman_test_DestinationSelect_node2();
			condition_bt_APC_APC_Swordman_test_DestinationSelect_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Swordman_test_DestinationSelect_node.SetId(2);
			sequence.AddChild(condition_bt_APC_APC_Swordman_test_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Swordman_test_DestinationSelect_node.HasEvents());
			Action_bt_APC_APC_Swordman_test_DestinationSelect_node3 action_bt_APC_APC_Swordman_test_DestinationSelect_node = new Action_bt_APC_APC_Swordman_test_DestinationSelect_node3();
			action_bt_APC_APC_Swordman_test_DestinationSelect_node.SetClassNameString("Action");
			action_bt_APC_APC_Swordman_test_DestinationSelect_node.SetId(3);
			sequence.AddChild(action_bt_APC_APC_Swordman_test_DestinationSelect_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_APC_Swordman_test_DestinationSelect_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			selector.AddChild(sequence2);
			Condition_bt_APC_APC_Swordman_test_DestinationSelect_node5 condition_bt_APC_APC_Swordman_test_DestinationSelect_node2 = new Condition_bt_APC_APC_Swordman_test_DestinationSelect_node5();
			condition_bt_APC_APC_Swordman_test_DestinationSelect_node2.SetClassNameString("Condition");
			condition_bt_APC_APC_Swordman_test_DestinationSelect_node2.SetId(5);
			sequence2.AddChild(condition_bt_APC_APC_Swordman_test_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Swordman_test_DestinationSelect_node2.HasEvents());
			Action_bt_APC_APC_Swordman_test_DestinationSelect_node6 action_bt_APC_APC_Swordman_test_DestinationSelect_node2 = new Action_bt_APC_APC_Swordman_test_DestinationSelect_node6();
			action_bt_APC_APC_Swordman_test_DestinationSelect_node2.SetClassNameString("Action");
			action_bt_APC_APC_Swordman_test_DestinationSelect_node2.SetId(6);
			sequence2.AddChild(action_bt_APC_APC_Swordman_test_DestinationSelect_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Swordman_test_DestinationSelect_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Action_bt_APC_APC_Swordman_test_DestinationSelect_node7 action_bt_APC_APC_Swordman_test_DestinationSelect_node3 = new Action_bt_APC_APC_Swordman_test_DestinationSelect_node7();
			action_bt_APC_APC_Swordman_test_DestinationSelect_node3.SetClassNameString("Action");
			action_bt_APC_APC_Swordman_test_DestinationSelect_node3.SetId(7);
			selector.AddChild(action_bt_APC_APC_Swordman_test_DestinationSelect_node3);
			selector.SetHasEvents(selector.HasEvents() | action_bt_APC_APC_Swordman_test_DestinationSelect_node3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
