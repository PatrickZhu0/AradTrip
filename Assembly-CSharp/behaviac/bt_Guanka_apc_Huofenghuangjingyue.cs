using System;

namespace behaviac
{
	// Token: 0x02002A80 RID: 10880
	public static class bt_Guanka_apc_Huofenghuangjingyue
	{
		// Token: 0x06013E26 RID: 81446 RVA: 0x005F6580 File Offset: 0x005F4980
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Guanka_apc/Huofenghuangjingyue");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Guanka_apc_Huofenghuangjingyue_node2 condition_bt_Guanka_apc_Huofenghuangjingyue_node = new Condition_bt_Guanka_apc_Huofenghuangjingyue_node2();
			condition_bt_Guanka_apc_Huofenghuangjingyue_node.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Huofenghuangjingyue_node.SetId(2);
			sequence.AddChild(condition_bt_Guanka_apc_Huofenghuangjingyue_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Guanka_apc_Huofenghuangjingyue_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			sequence.AddChild(sequence2);
			Condition_bt_Guanka_apc_Huofenghuangjingyue_node4 condition_bt_Guanka_apc_Huofenghuangjingyue_node2 = new Condition_bt_Guanka_apc_Huofenghuangjingyue_node4();
			condition_bt_Guanka_apc_Huofenghuangjingyue_node2.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Huofenghuangjingyue_node2.SetId(4);
			sequence2.AddChild(condition_bt_Guanka_apc_Huofenghuangjingyue_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Guanka_apc_Huofenghuangjingyue_node2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(5);
			sequence2.AddChild(sequence3);
			Condition_bt_Guanka_apc_Huofenghuangjingyue_node6 condition_bt_Guanka_apc_Huofenghuangjingyue_node3 = new Condition_bt_Guanka_apc_Huofenghuangjingyue_node6();
			condition_bt_Guanka_apc_Huofenghuangjingyue_node3.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Huofenghuangjingyue_node3.SetId(6);
			sequence3.AddChild(condition_bt_Guanka_apc_Huofenghuangjingyue_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Guanka_apc_Huofenghuangjingyue_node3.HasEvents());
			Action_bt_Guanka_apc_Huofenghuangjingyue_node7 action_bt_Guanka_apc_Huofenghuangjingyue_node = new Action_bt_Guanka_apc_Huofenghuangjingyue_node7();
			action_bt_Guanka_apc_Huofenghuangjingyue_node.SetClassNameString("Action");
			action_bt_Guanka_apc_Huofenghuangjingyue_node.SetId(7);
			sequence3.AddChild(action_bt_Guanka_apc_Huofenghuangjingyue_node);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Guanka_apc_Huofenghuangjingyue_node.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | sequence3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(8);
			selector.AddChild(sequence4);
			Condition_bt_Guanka_apc_Huofenghuangjingyue_node9 condition_bt_Guanka_apc_Huofenghuangjingyue_node4 = new Condition_bt_Guanka_apc_Huofenghuangjingyue_node9();
			condition_bt_Guanka_apc_Huofenghuangjingyue_node4.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Huofenghuangjingyue_node4.SetId(9);
			sequence4.AddChild(condition_bt_Guanka_apc_Huofenghuangjingyue_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Guanka_apc_Huofenghuangjingyue_node4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(10);
			sequence4.AddChild(sequence5);
			Condition_bt_Guanka_apc_Huofenghuangjingyue_node11 condition_bt_Guanka_apc_Huofenghuangjingyue_node5 = new Condition_bt_Guanka_apc_Huofenghuangjingyue_node11();
			condition_bt_Guanka_apc_Huofenghuangjingyue_node5.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Huofenghuangjingyue_node5.SetId(11);
			sequence5.AddChild(condition_bt_Guanka_apc_Huofenghuangjingyue_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_Huofenghuangjingyue_node5.HasEvents());
			Condition_bt_Guanka_apc_Huofenghuangjingyue_node14 condition_bt_Guanka_apc_Huofenghuangjingyue_node6 = new Condition_bt_Guanka_apc_Huofenghuangjingyue_node14();
			condition_bt_Guanka_apc_Huofenghuangjingyue_node6.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Huofenghuangjingyue_node6.SetId(14);
			sequence5.AddChild(condition_bt_Guanka_apc_Huofenghuangjingyue_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_Huofenghuangjingyue_node6.HasEvents());
			Action_bt_Guanka_apc_Huofenghuangjingyue_node12 action_bt_Guanka_apc_Huofenghuangjingyue_node2 = new Action_bt_Guanka_apc_Huofenghuangjingyue_node12();
			action_bt_Guanka_apc_Huofenghuangjingyue_node2.SetClassNameString("Action");
			action_bt_Guanka_apc_Huofenghuangjingyue_node2.SetId(12);
			sequence5.AddChild(action_bt_Guanka_apc_Huofenghuangjingyue_node2);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Guanka_apc_Huofenghuangjingyue_node2.HasEvents());
			sequence4.SetHasEvents(sequence4.HasEvents() | sequence5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
