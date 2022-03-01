using System;

namespace behaviac
{
	// Token: 0x02001D5C RID: 7516
	public static class bt_APC_APC_Husong_Aganzuo_Action
	{
		// Token: 0x06012477 RID: 74871 RVA: 0x0055511C File Offset: 0x0055351C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Husong_Aganzuo_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(3);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node1 condition_bt_APC_APC_Husong_Aganzuo_Action_node = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node1();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node.SetId(1);
			sequence.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node.HasEvents());
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node2 condition_bt_APC_APC_Husong_Aganzuo_Action_node2 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node2();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node2.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node2.SetId(2);
			sequence.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node2.HasEvents());
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node4 condition_bt_APC_APC_Husong_Aganzuo_Action_node3 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node4();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node3.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node3.SetId(4);
			sequence.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node3.HasEvents());
			Action_bt_APC_APC_Husong_Aganzuo_Action_node5 action_bt_APC_APC_Husong_Aganzuo_Action_node = new Action_bt_APC_APC_Husong_Aganzuo_Action_node5();
			action_bt_APC_APC_Husong_Aganzuo_Action_node.SetClassNameString("Action");
			action_bt_APC_APC_Husong_Aganzuo_Action_node.SetId(5);
			sequence.AddChild(action_bt_APC_APC_Husong_Aganzuo_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_APC_Husong_Aganzuo_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(6);
			selector.AddChild(sequence2);
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node7 condition_bt_APC_APC_Husong_Aganzuo_Action_node4 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node7();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node4.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node4.SetId(7);
			sequence2.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node4.HasEvents());
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node8 condition_bt_APC_APC_Husong_Aganzuo_Action_node5 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node8();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node5.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node5.SetId(8);
			sequence2.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node5.HasEvents());
			Action_bt_APC_APC_Husong_Aganzuo_Action_node10 action_bt_APC_APC_Husong_Aganzuo_Action_node2 = new Action_bt_APC_APC_Husong_Aganzuo_Action_node10();
			action_bt_APC_APC_Husong_Aganzuo_Action_node2.SetClassNameString("Action");
			action_bt_APC_APC_Husong_Aganzuo_Action_node2.SetId(10);
			sequence2.AddChild(action_bt_APC_APC_Husong_Aganzuo_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Husong_Aganzuo_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(9);
			selector.AddChild(sequence3);
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node11 condition_bt_APC_APC_Husong_Aganzuo_Action_node6 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node11();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node6.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node6.SetId(11);
			sequence3.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node6.HasEvents());
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node12 condition_bt_APC_APC_Husong_Aganzuo_Action_node7 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node12();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node7.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node7.SetId(12);
			sequence3.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node7.HasEvents());
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node13 condition_bt_APC_APC_Husong_Aganzuo_Action_node8 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node13();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node8.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node8.SetId(13);
			sequence3.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node8.HasEvents());
			Action_bt_APC_APC_Husong_Aganzuo_Action_node14 action_bt_APC_APC_Husong_Aganzuo_Action_node3 = new Action_bt_APC_APC_Husong_Aganzuo_Action_node14();
			action_bt_APC_APC_Husong_Aganzuo_Action_node3.SetClassNameString("Action");
			action_bt_APC_APC_Husong_Aganzuo_Action_node3.SetId(14);
			sequence3.AddChild(action_bt_APC_APC_Husong_Aganzuo_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_APC_APC_Husong_Aganzuo_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(15);
			selector.AddChild(sequence4);
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node16 condition_bt_APC_APC_Husong_Aganzuo_Action_node9 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node16();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node9.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node9.SetId(16);
			sequence4.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node9);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node9.HasEvents());
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node17 condition_bt_APC_APC_Husong_Aganzuo_Action_node10 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node17();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node10.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node10.SetId(17);
			sequence4.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node10.HasEvents());
			Condition_bt_APC_APC_Husong_Aganzuo_Action_node18 condition_bt_APC_APC_Husong_Aganzuo_Action_node11 = new Condition_bt_APC_APC_Husong_Aganzuo_Action_node18();
			condition_bt_APC_APC_Husong_Aganzuo_Action_node11.SetClassNameString("Condition");
			condition_bt_APC_APC_Husong_Aganzuo_Action_node11.SetId(18);
			sequence4.AddChild(condition_bt_APC_APC_Husong_Aganzuo_Action_node11);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_APC_APC_Husong_Aganzuo_Action_node11.HasEvents());
			Action_bt_APC_APC_Husong_Aganzuo_Action_node19 action_bt_APC_APC_Husong_Aganzuo_Action_node4 = new Action_bt_APC_APC_Husong_Aganzuo_Action_node19();
			action_bt_APC_APC_Husong_Aganzuo_Action_node4.SetClassNameString("Action");
			action_bt_APC_APC_Husong_Aganzuo_Action_node4.SetId(19);
			sequence4.AddChild(action_bt_APC_APC_Husong_Aganzuo_Action_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_APC_APC_Husong_Aganzuo_Action_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
