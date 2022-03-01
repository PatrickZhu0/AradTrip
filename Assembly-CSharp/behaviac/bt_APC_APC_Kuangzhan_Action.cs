using System;

namespace behaviac
{
	// Token: 0x02001DBA RID: 7610
	public static class bt_APC_APC_Kuangzhan_Action
	{
		// Token: 0x0601252D RID: 75053 RVA: 0x00559758 File Offset: 0x00557B58
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("APC/APC_Kuangzhan_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(13);
			selector.AddChild(sequence);
			Condition_bt_APC_APC_Kuangzhan_Action_node2 condition_bt_APC_APC_Kuangzhan_Action_node = new Condition_bt_APC_APC_Kuangzhan_Action_node2();
			condition_bt_APC_APC_Kuangzhan_Action_node.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node.SetId(2);
			sequence.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node8 condition_bt_APC_APC_Kuangzhan_Action_node2 = new Condition_bt_APC_APC_Kuangzhan_Action_node8();
			condition_bt_APC_APC_Kuangzhan_Action_node2.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node2.SetId(8);
			sequence.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node2.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node3 condition_bt_APC_APC_Kuangzhan_Action_node3 = new Condition_bt_APC_APC_Kuangzhan_Action_node3();
			condition_bt_APC_APC_Kuangzhan_Action_node3.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node3.SetId(3);
			sequence.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node3.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node16 condition_bt_APC_APC_Kuangzhan_Action_node4 = new Condition_bt_APC_APC_Kuangzhan_Action_node16();
			condition_bt_APC_APC_Kuangzhan_Action_node4.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node4.SetId(16);
			sequence.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node4);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node4.HasEvents());
			Action_bt_APC_APC_Kuangzhan_Action_node15 action_bt_APC_APC_Kuangzhan_Action_node = new Action_bt_APC_APC_Kuangzhan_Action_node15();
			action_bt_APC_APC_Kuangzhan_Action_node.SetClassNameString("Action");
			action_bt_APC_APC_Kuangzhan_Action_node.SetId(15);
			sequence.AddChild(action_bt_APC_APC_Kuangzhan_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_APC_APC_Kuangzhan_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(4);
			selector.AddChild(sequence2);
			Condition_bt_APC_APC_Kuangzhan_Action_node1 condition_bt_APC_APC_Kuangzhan_Action_node5 = new Condition_bt_APC_APC_Kuangzhan_Action_node1();
			condition_bt_APC_APC_Kuangzhan_Action_node5.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node5.SetId(1);
			sequence2.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node5.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node5 condition_bt_APC_APC_Kuangzhan_Action_node6 = new Condition_bt_APC_APC_Kuangzhan_Action_node5();
			condition_bt_APC_APC_Kuangzhan_Action_node6.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node6.SetId(5);
			sequence2.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node6.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node14 condition_bt_APC_APC_Kuangzhan_Action_node7 = new Condition_bt_APC_APC_Kuangzhan_Action_node14();
			condition_bt_APC_APC_Kuangzhan_Action_node7.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node7.SetId(14);
			sequence2.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node7);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node7.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node6 condition_bt_APC_APC_Kuangzhan_Action_node8 = new Condition_bt_APC_APC_Kuangzhan_Action_node6();
			condition_bt_APC_APC_Kuangzhan_Action_node8.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node8.SetId(6);
			sequence2.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node8);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node8.HasEvents());
			Action_bt_APC_APC_Kuangzhan_Action_node7 action_bt_APC_APC_Kuangzhan_Action_node2 = new Action_bt_APC_APC_Kuangzhan_Action_node7();
			action_bt_APC_APC_Kuangzhan_Action_node2.SetClassNameString("Action");
			action_bt_APC_APC_Kuangzhan_Action_node2.SetId(7);
			sequence2.AddChild(action_bt_APC_APC_Kuangzhan_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_APC_APC_Kuangzhan_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(9);
			selector.AddChild(sequence3);
			Condition_bt_APC_APC_Kuangzhan_Action_node10 condition_bt_APC_APC_Kuangzhan_Action_node9 = new Condition_bt_APC_APC_Kuangzhan_Action_node10();
			condition_bt_APC_APC_Kuangzhan_Action_node9.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node9.SetId(10);
			sequence3.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node9);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node9.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node18 condition_bt_APC_APC_Kuangzhan_Action_node10 = new Condition_bt_APC_APC_Kuangzhan_Action_node18();
			condition_bt_APC_APC_Kuangzhan_Action_node10.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node10.SetId(18);
			sequence3.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node10);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node10.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node11 condition_bt_APC_APC_Kuangzhan_Action_node11 = new Condition_bt_APC_APC_Kuangzhan_Action_node11();
			condition_bt_APC_APC_Kuangzhan_Action_node11.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node11.SetId(11);
			sequence3.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node11);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node11.HasEvents());
			Condition_bt_APC_APC_Kuangzhan_Action_node12 condition_bt_APC_APC_Kuangzhan_Action_node12 = new Condition_bt_APC_APC_Kuangzhan_Action_node12();
			condition_bt_APC_APC_Kuangzhan_Action_node12.SetClassNameString("Condition");
			condition_bt_APC_APC_Kuangzhan_Action_node12.SetId(12);
			sequence3.AddChild(condition_bt_APC_APC_Kuangzhan_Action_node12);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_APC_APC_Kuangzhan_Action_node12.HasEvents());
			Action_bt_APC_APC_Kuangzhan_Action_node17 action_bt_APC_APC_Kuangzhan_Action_node3 = new Action_bt_APC_APC_Kuangzhan_Action_node17();
			action_bt_APC_APC_Kuangzhan_Action_node3.SetClassNameString("Action");
			action_bt_APC_APC_Kuangzhan_Action_node3.SetId(17);
			sequence3.AddChild(action_bt_APC_APC_Kuangzhan_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_APC_APC_Kuangzhan_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
