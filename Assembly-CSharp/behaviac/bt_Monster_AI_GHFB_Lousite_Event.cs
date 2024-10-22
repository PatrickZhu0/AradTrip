﻿using System;

namespace behaviac
{
	// Token: 0x020032D6 RID: 13014
	public static class bt_Monster_AI_GHFB_Lousite_Event
	{
		// Token: 0x06014E1D RID: 85533 RVA: 0x0064A634 File Offset: 0x00648A34
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GHFB/Lousite_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(24);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(3);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_GHFB_Lousite_Event_node16 condition_bt_Monster_AI_GHFB_Lousite_Event_node = new Condition_bt_Monster_AI_GHFB_Lousite_Event_node16();
			condition_bt_Monster_AI_GHFB_Lousite_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_Lousite_Event_node.SetId(16);
			sequence.AddChild(condition_bt_Monster_AI_GHFB_Lousite_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GHFB_Lousite_Event_node.HasEvents());
			Selector selector2 = new Selector();
			selector2.SetClassNameString("Selector");
			selector2.SetId(8);
			sequence.AddChild(selector2);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(12);
			selector2.AddChild(sequence2);
			Condition_bt_Monster_AI_GHFB_Lousite_Event_node6 condition_bt_Monster_AI_GHFB_Lousite_Event_node2 = new Condition_bt_Monster_AI_GHFB_Lousite_Event_node6();
			condition_bt_Monster_AI_GHFB_Lousite_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_Lousite_Event_node2.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_GHFB_Lousite_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GHFB_Lousite_Event_node2.HasEvents());
			Action_bt_Monster_AI_GHFB_Lousite_Event_node11 action_bt_Monster_AI_GHFB_Lousite_Event_node = new Action_bt_Monster_AI_GHFB_Lousite_Event_node11();
			action_bt_Monster_AI_GHFB_Lousite_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_Lousite_Event_node.SetId(11);
			sequence2.AddChild(action_bt_Monster_AI_GHFB_Lousite_Event_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GHFB_Lousite_Event_node.HasEvents());
			selector2.SetHasEvents(selector2.HasEvents() | sequence2.HasEvents());
			Noop noop = new Noop();
			noop.SetClassNameString("Noop");
			noop.SetId(10);
			selector2.AddChild(noop);
			selector2.SetHasEvents(selector2.HasEvents() | noop.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(2);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_GHFB_Lousite_Event_node0 condition_bt_Monster_AI_GHFB_Lousite_Event_node3 = new Condition_bt_Monster_AI_GHFB_Lousite_Event_node0();
			condition_bt_Monster_AI_GHFB_Lousite_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_Lousite_Event_node3.SetId(0);
			sequence3.AddChild(condition_bt_Monster_AI_GHFB_Lousite_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_GHFB_Lousite_Event_node3.HasEvents());
			Selector selector3 = new Selector();
			selector3.SetClassNameString("Selector");
			selector3.SetId(13);
			sequence3.AddChild(selector3);
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(19);
			selector3.AddChild(sequence4);
			Condition_bt_Monster_AI_GHFB_Lousite_Event_node14 condition_bt_Monster_AI_GHFB_Lousite_Event_node4 = new Condition_bt_Monster_AI_GHFB_Lousite_Event_node14();
			condition_bt_Monster_AI_GHFB_Lousite_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_Lousite_Event_node4.SetId(14);
			sequence4.AddChild(condition_bt_Monster_AI_GHFB_Lousite_Event_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_GHFB_Lousite_Event_node4.HasEvents());
			Action_bt_Monster_AI_GHFB_Lousite_Event_node15 action_bt_Monster_AI_GHFB_Lousite_Event_node2 = new Action_bt_Monster_AI_GHFB_Lousite_Event_node15();
			action_bt_Monster_AI_GHFB_Lousite_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_Lousite_Event_node2.SetId(15);
			sequence4.AddChild(action_bt_Monster_AI_GHFB_Lousite_Event_node2);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_GHFB_Lousite_Event_node2.HasEvents());
			selector3.SetHasEvents(selector3.HasEvents() | sequence4.HasEvents());
			Noop noop2 = new Noop();
			noop2.SetClassNameString("Noop");
			noop2.SetId(20);
			selector3.AddChild(noop2);
			selector3.SetHasEvents(selector3.HasEvents() | noop2.HasEvents());
			sequence3.SetHasEvents(sequence3.HasEvents() | selector3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(1);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_GHFB_Lousite_Event_node9 condition_bt_Monster_AI_GHFB_Lousite_Event_node5 = new Condition_bt_Monster_AI_GHFB_Lousite_Event_node9();
			condition_bt_Monster_AI_GHFB_Lousite_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_Lousite_Event_node5.SetId(9);
			sequence5.AddChild(condition_bt_Monster_AI_GHFB_Lousite_Event_node5);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_GHFB_Lousite_Event_node5.HasEvents());
			Selector selector4 = new Selector();
			selector4.SetClassNameString("Selector");
			selector4.SetId(21);
			sequence5.AddChild(selector4);
			Sequence sequence6 = new Sequence();
			sequence6.SetClassNameString("Sequence");
			sequence6.SetId(22);
			selector4.AddChild(sequence6);
			Condition_bt_Monster_AI_GHFB_Lousite_Event_node17 condition_bt_Monster_AI_GHFB_Lousite_Event_node6 = new Condition_bt_Monster_AI_GHFB_Lousite_Event_node17();
			condition_bt_Monster_AI_GHFB_Lousite_Event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_Lousite_Event_node6.SetId(17);
			sequence6.AddChild(condition_bt_Monster_AI_GHFB_Lousite_Event_node6);
			sequence6.SetHasEvents(sequence6.HasEvents() | condition_bt_Monster_AI_GHFB_Lousite_Event_node6.HasEvents());
			Action_bt_Monster_AI_GHFB_Lousite_Event_node18 action_bt_Monster_AI_GHFB_Lousite_Event_node3 = new Action_bt_Monster_AI_GHFB_Lousite_Event_node18();
			action_bt_Monster_AI_GHFB_Lousite_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_Lousite_Event_node3.SetId(18);
			sequence6.AddChild(action_bt_Monster_AI_GHFB_Lousite_Event_node3);
			sequence6.SetHasEvents(sequence6.HasEvents() | action_bt_Monster_AI_GHFB_Lousite_Event_node3.HasEvents());
			selector4.SetHasEvents(selector4.HasEvents() | sequence6.HasEvents());
			Noop noop3 = new Noop();
			noop3.SetClassNameString("Noop");
			noop3.SetId(23);
			selector4.AddChild(noop3);
			selector4.SetHasEvents(selector4.HasEvents() | noop3.HasEvents());
			sequence5.SetHasEvents(sequence5.HasEvents() | selector4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			Sequence sequence7 = new Sequence();
			sequence7.SetClassNameString("Sequence");
			sequence7.SetId(4);
			selector.AddChild(sequence7);
			Condition_bt_Monster_AI_GHFB_Lousite_Event_node7 condition_bt_Monster_AI_GHFB_Lousite_Event_node7 = new Condition_bt_Monster_AI_GHFB_Lousite_Event_node7();
			condition_bt_Monster_AI_GHFB_Lousite_Event_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_GHFB_Lousite_Event_node7.SetId(7);
			sequence7.AddChild(condition_bt_Monster_AI_GHFB_Lousite_Event_node7);
			sequence7.SetHasEvents(sequence7.HasEvents() | condition_bt_Monster_AI_GHFB_Lousite_Event_node7.HasEvents());
			Action_bt_Monster_AI_GHFB_Lousite_Event_node5 action_bt_Monster_AI_GHFB_Lousite_Event_node4 = new Action_bt_Monster_AI_GHFB_Lousite_Event_node5();
			action_bt_Monster_AI_GHFB_Lousite_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_GHFB_Lousite_Event_node4.SetId(5);
			sequence7.AddChild(action_bt_Monster_AI_GHFB_Lousite_Event_node4);
			sequence7.SetHasEvents(sequence7.HasEvents() | action_bt_Monster_AI_GHFB_Lousite_Event_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence7.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
