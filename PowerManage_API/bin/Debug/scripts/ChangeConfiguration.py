print ""
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)
print "##################### Change Configuration #########################"
time.sleep (0.5)
print "####################################################################"
time.sleep (0.5)

key = 'PP_G_CODE_1'
value = "0000"
text = '{"diff":[["' + key +'","' + value + '"]],"version":474112}'

for _panel in list_of_panels:
	p = panel.Panel(_panel)
	task = p.ChangeConfiguration(text)
	task_list.append(task)
	task.next()
	
for task in task_list:
	for i in task:		
		if i.IsInProgress():
			SendData ("Checking PMaxConfigUpload for %s..." % i.PanelID())
			time.sleep (5)
		
		if i.IsFailed():
			SendData ("PMaxConfigUpload %s FAILED    : %s." % (i.PanelID(), i.GetError()))
				
		if i.IsSucceeded():
			SendData ("PMaxConfigUpload %s SUCCEEDED." % i.PanelID())
			time.sleep (0.5)
			
		time.sleep (0.5)