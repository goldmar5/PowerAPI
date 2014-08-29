print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "######################### Get Troubles #############################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)


for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.GetMemory()
	task_list.append(task)
	task.next()
	
for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking process PMaxStateGet for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxStateGet %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxStateGet %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			SendData ("List of troubles (%s): %s" % (i.PanelID(), ','.join ([str(t) for t in i.GetResult()] )))
			time.sleep (0.5)
			
		time.sleep (0.5)