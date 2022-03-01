using System;

namespace behaviac
{
	// Token: 0x02002A1F RID: 10783
	public static class bt_Guanka_apc_Bawanghuatiexin_xin
	{
		// Token: 0x06013D6D RID: 81261 RVA: 0x005F0CAC File Offset: 0x005EF0AC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Guanka_apc/Bawanghuatiexin_xin");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(9);
			selector.AddChild(sequence);
			Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node10 condition_bt_Guanka_apc_Bawanghuatiexin_xin_node = new Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node10();
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node.SetId(10);
			sequence.AddChild(condition_bt_Guanka_apc_Bawanghuatiexin_xin_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Guanka_apc_Bawanghuatiexin_xin_node.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(11);
			sequence.AddChild(sequence2);
			Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node12 condition_bt_Guanka_apc_Bawanghuatiexin_xin_node2 = new Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node12();
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node2.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node2.SetId(12);
			sequence2.AddChild(condition_bt_Guanka_apc_Bawanghuatiexin_xin_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Guanka_apc_Bawanghuatiexin_xin_node2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(13);
			sequence2.AddChild(sequence3);
			Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node14 condition_bt_Guanka_apc_Bawanghuatiexin_xin_node3 = new Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node14();
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node3.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node3.SetId(14);
			sequence3.AddChild(condition_bt_Guanka_apc_Bawanghuatiexin_xin_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Guanka_apc_Bawanghuatiexin_xin_node3.HasEvents());
			Action_bt_Guanka_apc_Bawanghuatiexin_xin_node15 action_bt_Guanka_apc_Bawanghuatiexin_xin_node = new Action_bt_Guanka_apc_Bawanghuatiexin_xin_node15();
			action_bt_Guanka_apc_Bawanghuatiexin_xin_node.SetClassNameString("Action");
			action_bt_Guanka_apc_Bawanghuatiexin_xin_node.SetId(15);
			sequence3.AddChild(action_bt_Guanka_apc_Bawanghuatiexin_xin_node);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Guanka_apc_Bawanghuatiexin_xin_node.HasEvents());
			sequence2.SetHasEvents(sequence2.HasEvents() | sequence3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | sequence2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(16);
			selector.AddChild(sequence4);
			Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node17 condition_bt_Guanka_apc_Bawanghuatiexin_xin_node4 = new Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node17();
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node4.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node4.SetId(17);
			sequence4.AddChild(condition_bt_Guanka_apc_Bawanghuatiexin_xin_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Guanka_apc_Bawanghuatiexin_xin_node4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(18);
			sequence4.AddChild(sequence5);
			Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node19 condition_bt_Guanka_apc_Bawanghuatiexin_xin_node5 = new Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node19();
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node5.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node5.SetId(19);
			sequence5.AddChild(condition_bt_Guanka_apc_Bawanghuatiexin_xin_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_Bawanghuatiexin_xin_node5.HasEvents());
			Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node20 condition_bt_Guanka_apc_Bawanghuatiexin_xin_node6 = new Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node20();
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node6.SetClassNameString("Condition");
			condition_bt_Guanka_apc_Bawanghuatiexin_xin_node6.SetId(20);
			sequence5.AddChild(condition_bt_Guanka_apc_Bawanghuatiexin_xin_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Guanka_apc_Bawanghuatiexin_xin_node6.HasEvents());
			Action_bt_Guanka_apc_Bawanghuatiexin_xin_node21 action_bt_Guanka_apc_Bawanghuatiexin_xin_node2 = new Action_bt_Guanka_apc_Bawanghuatiexin_xin_node21();
			action_bt_Guanka_apc_Bawanghuatiexin_xin_node2.SetClassNameString("Action");
			action_bt_Guanka_apc_Bawanghuatiexin_xin_node2.SetId(21);
			sequence5.AddChild(action_bt_Guanka_apc_Bawanghuatiexin_xin_node2);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Guanka_apc_Bawanghuatiexin_xin_node2.HasEvents());
			sequence4.SetHasEvents(sequence4.HasEvents() | sequence5.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
