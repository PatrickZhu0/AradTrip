using System;

namespace behaviac
{
	// Token: 0x02002A2C RID: 10796
	public static class bt_Guanka_apc_Cimeiguifeiyan
	{
		// Token: 0x06013D86 RID: 81286 RVA: 0x005F1804 File Offset: 0x005EFC04
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Guanka_apc/Cimeiguifeiyan");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node2 condition_bt_Guanka_apc_Cimeiguifeiyan_node = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node2();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node.SetId(2);
			sequence.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			sequence.AddChild(sequence2);
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node4 condition_bt_Guanka_apc_Cimeiguifeiyan_node2 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node4();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node2.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node2.SetId(4);
			sequence2.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(5);
			sequence2.AddChild(sequence3);
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node6 condition_bt_Guanka_apc_Cimeiguifeiyan_node3 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node6();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node3.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node3.SetId(6);
			sequence3.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node3.HasEvents());
			Action_bt_Guanka_apc_Cimeiguifeiyan_node7 action_bt_Guanka_apc_Cimeiguifeiyan_node = new Action_bt_Guanka_apc_Cimeiguifeiyan_node7();
			action_bt_Guanka_apc_Cimeiguifeiyan_node.SetClassNameString("Action");
			action_bt_Guanka_apc_Cimeiguifeiyan_node.SetId(7);
			sequence3.AddChild(action_bt_Guanka_apc_Cimeiguifeiyan_node);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Guanka_apc_Cimeiguifeiyan_node.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | sequence3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(8);
			selector.AddChild(sequence4);
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node9 condition_bt_Guanka_apc_Cimeiguifeiyan_node4 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node9();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node4.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node4.SetId(9);
			sequence4.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(10);
			sequence4.AddChild(sequence5);
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node11 condition_bt_Guanka_apc_Cimeiguifeiyan_node5 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node11();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node5.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node5.SetId(11);
			sequence5.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node5.HasEvents());
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node12 condition_bt_Guanka_apc_Cimeiguifeiyan_node6 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node12();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node6.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node6.SetId(12);
			sequence5.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node6.HasEvents());
			Action_bt_Guanka_apc_Cimeiguifeiyan_node13 action_bt_Guanka_apc_Cimeiguifeiyan_node2 = new Action_bt_Guanka_apc_Cimeiguifeiyan_node13();
			action_bt_Guanka_apc_Cimeiguifeiyan_node2.SetClassNameString("Action");
			action_bt_Guanka_apc_Cimeiguifeiyan_node2.SetId(13);
			sequence5.AddChild(action_bt_Guanka_apc_Cimeiguifeiyan_node2);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Guanka_apc_Cimeiguifeiyan_node2.HasEvents());
			sequence4.SetHasEvents(sequence4.HasEvents() | sequence5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(14);
			selector.AddChild(sequence6);
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node15 condition_bt_Guanka_apc_Cimeiguifeiyan_node7 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node15();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node7.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node7.SetId(15);
			sequence6.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node7);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node7.HasEvents());
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(16);
			sequence6.AddChild(sequence7);
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node17 condition_bt_Guanka_apc_Cimeiguifeiyan_node8 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node17();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node8.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node8.SetId(17);
			sequence7.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node8);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node8.HasEvents());
			Condition_bt_Guanka_apc_Cimeiguifeiyan_node18 condition_bt_Guanka_apc_Cimeiguifeiyan_node9 = new Condition_bt_Guanka_apc_Cimeiguifeiyan_node18();
			condition_bt_Guanka_apc_Cimeiguifeiyan_node9.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Cimeiguifeiyan_node9.SetId(18);
			sequence7.AddChild(condition_bt_Guanka_apc_Cimeiguifeiyan_node9);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Guanka_apc_Cimeiguifeiyan_node9.HasEvents());
			Action_bt_Guanka_apc_Cimeiguifeiyan_node19 action_bt_Guanka_apc_Cimeiguifeiyan_node3 = new Action_bt_Guanka_apc_Cimeiguifeiyan_node19();
			action_bt_Guanka_apc_Cimeiguifeiyan_node3.SetClassNameString("Action");
			action_bt_Guanka_apc_Cimeiguifeiyan_node3.SetId(19);
			sequence7.AddChild(action_bt_Guanka_apc_Cimeiguifeiyan_node3);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Guanka_apc_Cimeiguifeiyan_node3.HasEvents());
			sequence6.SetHasEvents(sequence6.HasEvents() | sequence7.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence6.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
