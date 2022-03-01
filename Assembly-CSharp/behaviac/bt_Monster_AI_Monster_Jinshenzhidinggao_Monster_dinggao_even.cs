using System;

namespace behaviac
{
	// Token: 0x020036A7 RID: 13991
	public static class bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event
	{
		// Token: 0x0601556A RID: 87402 RVA: 0x0066FA2C File Offset: 0x0066DE2C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_Jinshenzhidinggao/Monster_dinggao_event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node19 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node19();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2.SetId(19);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node8 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node8();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(11);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node12 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node12();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4.SetId(12);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node13 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node13();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5.SetId(13);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node14 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node14();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3.SetId(14);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node3.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node18 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node18();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4.SetId(18);
			sequence2.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(24);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node26 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node26();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6.SetId(26);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6.HasEvents());
			Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node27 condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node7 = new Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node27();
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node7.SetId(27);
			sequence3.AddChild(condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node7);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node7.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node28 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node28();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5.SetId(28);
			sequence3.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node5.HasEvents());
			Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node33 action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6 = new Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node33();
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6.SetId(33);
			sequence3.AddChild(action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node6.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
