using System;

namespace behaviac
{
	// Token: 0x020036E4 RID: 14052
	public static class bt_Monster_AI_Monster_Nongbao_Nongbao_Event
	{
		// Token: 0x060155DE RID: 87518 RVA: 0x00672254 File Offset: 0x00670654
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Nongbao/Nongbao_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2.HasEvents());
			Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7 action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node = new Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7();
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node.SetId(7);
			sequence.AddChild(action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3.HasEvents());
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node9 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node9();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4.HasEvents());
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5.SetId(10);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node5.HasEvents());
			Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3 action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2 = new Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3();
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2.SetId(3);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(4);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node12 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node12();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6.SetId(12);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node6.HasEvents());
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node13 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node13();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7.SetId(13);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node7.HasEvents());
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node14 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node14();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8.SetId(14);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node8.HasEvents());
			Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node15 action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3 = new Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node15();
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3.SetId(15);
			sequence3.AddChild(action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(11);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node16 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node9 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node16();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node9.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node9.SetId(16);
			sequence4.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node9);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node9.HasEvents());
			Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node17 condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10 = new Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node17();
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10.SetId(17);
			sequence4.AddChild(condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10.HasEvents());
			Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node18 action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4 = new Action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node18();
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4.SetId(18);
			sequence4.AddChild(action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
