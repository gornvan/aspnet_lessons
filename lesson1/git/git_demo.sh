# https://git-scm.com/download/win

# initialize new repository
git init

# create a file with a hello
echo 'Console.WriteLine("Hello Git!")' > Program.cs

# show current status
git status

# plan Program.cs for the commit
git add Program.cs

# identify ourselves
git config --global user.email "you@example.com"
git config --global user.name "Ivan Ilin"

# create a commit
git commit -m 'Create Progam!'

# create a branch and switch to it
git branch DoubleHello
git checkout DoubleHello

# another Hello
echo 'Console.WriteLine("Hello Git!")' >> Program.cs

# plan for commit and do it
git add Program.cs
git commit -m 'Say Hello another time!'

# go back to Master
git checkout master

# see all branches locally available
git branch

# "pull" DoubleHello branch into Master
git merge DoubleHello

# create GITHUB repo
# or on another SERVICE:
#  Bitbucket
#  Azure DevOps (for the brave ones)
#  whatever

# generate your ssh key (or skip this and authenticate some other way with your Git Server)
ssh-keygen
cat  ~/.ssh/id_rsa.pub
# then add the key as your trusted key on the SERVICE - use the contents of id_rsa.pub

# set a remote repository so we can push our code there (YOUR repository address needed)
git remote add gh git@github.com:gornvan/aspnet_lessons.git
# load info on the remote repo - there is already a Commit with the Readme or License

# on github, the first branch is "main", not "master" like in traditional git
git checkout --track gh/main

# merge master branch into main branch (if your default branch is master Git For Windows allow to configure it)
git merge master --allow-unrelated-histories
# the flag --allow-unrelated-histories makes git assume that the commits are actually related and compatible

# in case of source tree and github:
"C:\Program Files (x86)\Atlassian\SourceTree\tools\putty\plink.exe" github.com
or 
"C:\Users\user\AppData\Local\SourceTree\app-3.4.9\tools\putty\plink.exe" github.com # - just press y and enter and Ctrl+C to end it

# Source Tree: Tools -> Options -> general -> select SSH client

# to get the INIT commit from github: 
# git cherry-pick <commit hash>

# to see the INIT commit
# git checkout -b remote-master-2
# git reset --hard <remote>/master