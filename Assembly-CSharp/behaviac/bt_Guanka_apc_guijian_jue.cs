using System;

namespace behaviac
{
	// Token: 0x02002A63 RID: 10851
	public static class bt_Guanka_apc_guijian_jue
	{
		// Token: 0x06013DF0 RID: 81392 RVA: 0x005F4808 File Offset: 0x005F2C08
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Guanka_apc/guijian_jue");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Guanka_apc_guijian_jue_node2 condition_bt_Guanka_apc_guijian_jue_node = new Condition_bt_Guanka_apc_guijian_jue_node2();
			condition_bt_Guanka_apc_guijian_jue_node.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node.SetId(2);
			sequence.AddChild(condition_bt_Guanka_apc_guijian_jue_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			sequence.AddChild(sequence2);
			Condition_bt_Guanka_apc_guijian_jue_node4 condition_bt_Guanka_apc_guijian_jue_node2 = new Condition_bt_Guanka_apc_guijian_jue_node4();
			condition_bt_Guanka_apc_guijian_jue_node2.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node2.SetId(4);
			sequence2.AddChild(condition_bt_Guanka_apc_guijian_jue_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(5);
			sequence2.AddChild(sequence3);
			Condition_bt_Guanka_apc_guijian_jue_node6 condition_bt_Guanka_apc_guijian_jue_node3 = new Condition_bt_Guanka_apc_guijian_jue_node6();
			condition_bt_Guanka_apc_guijian_jue_node3.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node3.SetId(6);
			sequence3.AddChild(condition_bt_Guanka_apc_guijian_jue_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node3.HasEvents());
			Condition_bt_Guanka_apc_guijian_jue_node7 condition_bt_Guanka_apc_guijian_jue_node4 = new Condition_bt_Guanka_apc_guijian_jue_node7();
			condition_bt_Guanka_apc_guijian_jue_node4.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node4.SetId(7);
			sequence3.AddChild(condition_bt_Guanka_apc_guijian_jue_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node4.HasEvents());
			Action_bt_Guanka_apc_guijian_jue_node22 action_bt_Guanka_apc_guijian_jue_node = new Action_bt_Guanka_apc_guijian_jue_node22();
			action_bt_Guanka_apc_guijian_jue_node.SetClassNameString("Action");
			action_bt_Guanka_apc_guijian_jue_node.SetId(22);
			sequence3.AddChild(action_bt_Guanka_apc_guijian_jue_node);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Guanka_apc_guijian_jue_node.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | sequence3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(8);
			selector.AddChild(sequence4);
			Condition_bt_Guanka_apc_guijian_jue_node9 condition_bt_Guanka_apc_guijian_jue_node5 = new Condition_bt_Guanka_apc_guijian_jue_node9();
			condition_bt_Guanka_apc_guijian_jue_node5.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node5.SetId(9);
			sequence4.AddChild(condition_bt_Guanka_apc_guijian_jue_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node5.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(10);
			sequence4.AddChild(sequence5);
			Condition_bt_Guanka_apc_guijian_jue_node11 condition_bt_Guanka_apc_guijian_jue_node6 = new Condition_bt_Guanka_apc_guijian_jue_node11();
			condition_bt_Guanka_apc_guijian_jue_node6.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node6.SetId(11);
			sequence5.AddChild(condition_bt_Guanka_apc_guijian_jue_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node6.HasEvents());
			Condition_bt_Guanka_apc_guijian_jue_node14 condition_bt_Guanka_apc_guijian_jue_node7 = new Condition_bt_Guanka_apc_guijian_jue_node14();
			condition_bt_Guanka_apc_guijian_jue_node7.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node7.SetId(14);
			sequence5.AddChild(condition_bt_Guanka_apc_guijian_jue_node7);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node7.HasEvents());
			Action_bt_Guanka_apc_guijian_jue_node12 action_bt_Guanka_apc_guijian_jue_node2 = new Action_bt_Guanka_apc_guijian_jue_node12();
			action_bt_Guanka_apc_guijian_jue_node2.SetClassNameString("Action");
			action_bt_Guanka_apc_guijian_jue_node2.SetId(12);
			sequence5.AddChild(action_bt_Guanka_apc_guijian_jue_node2);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Guanka_apc_guijian_jue_node2.HasEvents());
			sequence4.SetHasEvents(sequence4.HasEvents() | sequence5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(16);
			selector.AddChild(sequence6);
			Condition_bt_Guanka_apc_guijian_jue_node17 condition_bt_Guanka_apc_guijian_jue_node8 = new Condition_bt_Guanka_apc_guijian_jue_node17();
			condition_bt_Guanka_apc_guijian_jue_node8.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node8.SetId(17);
			sequence6.AddChild(condition_bt_Guanka_apc_guijian_jue_node8);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node8.HasEvents());
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(18);
			sequence6.AddChild(sequence7);
			Condition_bt_Guanka_apc_guijian_jue_node19 condition_bt_Guanka_apc_guijian_jue_node9 = new Condition_bt_Guanka_apc_guijian_jue_node19();
			condition_bt_Guanka_apc_guijian_jue_node9.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node9.SetId(19);
			sequence7.AddChild(condition_bt_Guanka_apc_guijian_jue_node9);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node9.HasEvents());
			Condition_bt_Guanka_apc_guijian_jue_node20 condition_bt_Guanka_apc_guijian_jue_node10 = new Condition_bt_Guanka_apc_guijian_jue_node20();
			condition_bt_Guanka_apc_guijian_jue_node10.SetClassNameString("Condition");
			condition_bt_Guanka_apc_guijian_jue_node10.SetId(20);
			sequence7.AddChild(condition_bt_Guanka_apc_guijian_jue_node10);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Guanka_apc_guijian_jue_node10.HasEvents());
			Action_bt_Guanka_apc_guijian_jue_node13 action_bt_Guanka_apc_guijian_jue_node3 = new Action_bt_Guanka_apc_guijian_jue_node13();
			action_bt_Guanka_apc_guijian_jue_node3.SetClassNameString("Action");
			action_bt_Guanka_apc_guijian_jue_node3.SetId(13);
			sequence7.AddChild(action_bt_Guanka_apc_guijian_jue_node3);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Guanka_apc_guijian_jue_node3.HasEvents());
			sequence6.SetHasEvents(sequence6.HasEvents() | sequence7.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence6.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
