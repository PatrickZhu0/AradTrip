using System;

namespace behaviac
{
	// Token: 0x02001D0A RID: 7434
	public static class bt_APC_APC_Demian_Action
	{
		// Token: 0x060123D9 RID: 74713 RVA: 0x00550FD8 File Offset: 0x0054F3D8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Demian_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(2);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Demian_Action_node1 condition_bt_APC_APC_Demian_Action_node = new Condition_bt_APC_APC_Demian_Action_node1();
			condition_bt_APC_APC_Demian_Action_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node.SetId(1);
			sequence.AddChild(condition_bt_APC_APC_Demian_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Demian_Action_node.HasEvents());
			DecoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node3 decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node = new DecoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node3();
			decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node.SetClassNameString("DecoratorAlwaysSuccess");
			decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node.SetId(3);
			sequence.AddChild(decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node.AddChild(sequence2);
			Condition_bt_APC_APC_Demian_Action_node5 condition_bt_APC_APC_Demian_Action_node2 = new Condition_bt_APC_APC_Demian_Action_node5();
			condition_bt_APC_APC_Demian_Action_node2.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node2.SetId(5);
			sequence2.AddChild(condition_bt_APC_APC_Demian_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Demian_Action_node2.HasEvents());
			Condition_bt_APC_APC_Demian_Action_node6 condition_bt_APC_APC_Demian_Action_node3 = new Condition_bt_APC_APC_Demian_Action_node6();
			condition_bt_APC_APC_Demian_Action_node3.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node3.SetId(6);
			sequence2.AddChild(condition_bt_APC_APC_Demian_Action_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Demian_Action_node3.HasEvents());
			Action_bt_APC_APC_Demian_Action_node7 action_bt_APC_APC_Demian_Action_node = new Action_bt_APC_APC_Demian_Action_node7();
			action_bt_APC_APC_Demian_Action_node.SetClassNameString("Action");
			action_bt_APC_APC_Demian_Action_node.SetId(7);
			sequence2.AddChild(action_bt_APC_APC_Demian_Action_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Demian_Action_node.HasEvents());
			decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node.SetHasEvents(decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node.HasEvents() | sequence2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | decoratorAlwaysSuccess_bt_APC_APC_Demian_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(8);
			selector.AddChild(sequence3);
			Condition_bt_APC_APC_Demian_Action_node9 condition_bt_APC_APC_Demian_Action_node4 = new Condition_bt_APC_APC_Demian_Action_node9();
			condition_bt_APC_APC_Demian_Action_node4.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node4.SetId(9);
			sequence3.AddChild(condition_bt_APC_APC_Demian_Action_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Demian_Action_node4.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(10);
			sequence3.AddChild(sequence4);
			Condition_bt_APC_APC_Demian_Action_node11 condition_bt_APC_APC_Demian_Action_node5 = new Condition_bt_APC_APC_Demian_Action_node11();
			condition_bt_APC_APC_Demian_Action_node5.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node5.SetId(11);
			sequence4.AddChild(condition_bt_APC_APC_Demian_Action_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Demian_Action_node5.HasEvents());
			Condition_bt_APC_APC_Demian_Action_node12 condition_bt_APC_APC_Demian_Action_node6 = new Condition_bt_APC_APC_Demian_Action_node12();
			condition_bt_APC_APC_Demian_Action_node6.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node6.SetId(12);
			sequence4.AddChild(condition_bt_APC_APC_Demian_Action_node6);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Demian_Action_node6.HasEvents());
			Action_bt_APC_APC_Demian_Action_node13 action_bt_APC_APC_Demian_Action_node2 = new Action_bt_APC_APC_Demian_Action_node13();
			action_bt_APC_APC_Demian_Action_node2.SetClassNameString("Action");
			action_bt_APC_APC_Demian_Action_node2.SetId(13);
			sequence4.AddChild(action_bt_APC_APC_Demian_Action_node2);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_APC_APC_Demian_Action_node2.HasEvents());
			sequence3.SetHasEvents(sequence3.HasEvents() | sequence4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(14);
			selector.AddChild(sequence5);
			Condition_bt_APC_APC_Demian_Action_node15 condition_bt_APC_APC_Demian_Action_node7 = new Condition_bt_APC_APC_Demian_Action_node15();
			condition_bt_APC_APC_Demian_Action_node7.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node7.SetId(15);
			sequence5.AddChild(condition_bt_APC_APC_Demian_Action_node7);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_APC_APC_Demian_Action_node7.HasEvents());
			Condition_bt_APC_APC_Demian_Action_node16 condition_bt_APC_APC_Demian_Action_node8 = new Condition_bt_APC_APC_Demian_Action_node16();
			condition_bt_APC_APC_Demian_Action_node8.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node8.SetId(16);
			sequence5.AddChild(condition_bt_APC_APC_Demian_Action_node8);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_APC_APC_Demian_Action_node8.HasEvents());
			Condition_bt_APC_APC_Demian_Action_node17 condition_bt_APC_APC_Demian_Action_node9 = new Condition_bt_APC_APC_Demian_Action_node17();
			condition_bt_APC_APC_Demian_Action_node9.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node9.SetId(17);
			sequence5.AddChild(condition_bt_APC_APC_Demian_Action_node9);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_APC_APC_Demian_Action_node9.HasEvents());
			Condition_bt_APC_APC_Demian_Action_node19 condition_bt_APC_APC_Demian_Action_node10 = new Condition_bt_APC_APC_Demian_Action_node19();
			condition_bt_APC_APC_Demian_Action_node10.SetClassNameString("Condition");
			condition_bt_APC_APC_Demian_Action_node10.SetId(19);
			sequence5.AddChild(condition_bt_APC_APC_Demian_Action_node10);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_APC_APC_Demian_Action_node10.HasEvents());
			Action_bt_APC_APC_Demian_Action_node18 action_bt_APC_APC_Demian_Action_node3 = new Action_bt_APC_APC_Demian_Action_node18();
			action_bt_APC_APC_Demian_Action_node3.SetClassNameString("Action");
			action_bt_APC_APC_Demian_Action_node3.SetId(18);
			sequence5.AddChild(action_bt_APC_APC_Demian_Action_node3);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_APC_APC_Demian_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
