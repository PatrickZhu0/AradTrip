using System;

namespace behaviac
{
	// Token: 0x020030B4 RID: 12468
	public static class bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event
	{
		// Token: 0x06014A29 RID: 84521 RVA: 0x00636A68 File Offset: 0x00634E68
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/BOSS_EVENT/BOSS_EVENT_beijibati_event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node1 action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node = new Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node1();
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.SetClassNameString("Action");
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.SetId(1);
			sequence.AddChild(action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.HasEvents());
			DecoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node3 decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node = new DecoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node3();
			decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.SetClassNameString("DecoratorAlwaysSuccess");
			decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.SetId(3);
			sequence.AddChild(decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node5 condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node = new Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node5();
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.HasEvents());
			Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node6 condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2 = new Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node6();
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2.HasEvents());
			Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node7 action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2 = new Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node7();
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2.SetId(7);
			sequence2.AddChild(action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node2.HasEvents());
			decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.SetHasEvents(decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.HasEvents() | sequence2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | decoratorAlwaysSuccess_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
