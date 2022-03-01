using System;

namespace behaviac
{
	// Token: 0x02003DBB RID: 15803
	public static class bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD
	{
		// Token: 0x06016306 RID: 90886 RVA: 0x006B5164 File Offset: 0x006B3564
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Weishi_chuiwang/Weishi_chuiwang_Event_jianCD");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(1);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3 condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node = new Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3();
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node.SetId(4);
			sequence2.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2.SetId(5);
			sequence2.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(7);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8 condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2 = new Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8();
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2.SetId(8);
			sequence3.AddChild(condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node2.HasEvents());
			Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9 condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3 = new Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9();
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3.SetId(9);
			sequence3.AddChild(condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node3.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node10 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node10();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4.SetId(10);
			sequence3.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(11);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node12 condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4 = new Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node12();
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4.SetId(12);
			sequence4.AddChild(condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node4.HasEvents());
			Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node13 condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5 = new Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node13();
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5.SetId(13);
			sequence4.AddChild(condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node15 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node15();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5.SetId(15);
			sequence4.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node5.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node14 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node14();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6.SetId(14);
			sequence4.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Sequence sequence5 = new Sequence();
			sequence5.SetClassNameString("Sequence");
			sequence5.SetId(16);
			selector.AddChild(sequence5);
			Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node17 condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6 = new Condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node17();
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6.SetId(17);
			sequence5.AddChild(condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6);
			sequence5.SetHasEvents(sequence5.HasEvents() | condition_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node6.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node19 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node7 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node19();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node7.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node7.SetId(19);
			sequence5.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node7);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node7.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node18 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node18();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8.SetId(18);
			sequence5.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node8.HasEvents());
			Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node20 action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9 = new Action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node20();
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9.SetClassNameString("Action");
			action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9.SetId(20);
			sequence5.AddChild(action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9);
			sequence5.SetHasEvents(sequence5.HasEvents() | action_bt_Monster_AI_Weishi_chuiwang_Weishi_chuiwang_Event_jianCD_node9.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence5.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
