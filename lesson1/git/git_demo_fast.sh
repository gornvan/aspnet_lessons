# register on GITHUB
# create a REPO

# generate your ssh key (or skip this and authenticate some other way with your Git Server)
ssh-keygen
cat  ~/.ssh/id_rsa.pub
# then add the key as your trusted key on the SERVICE - use the contents of id_rsa.pub

# Copy repository url by clicking on Code -> SSH -> Copy URL

# open console where you want the project to reside and clone the repo
git clone <repository URL>

# inside the new directory with your repo, run:
dotnet new mvc

# add all for commit
git add .

# commit 
git commig -m 'create template mvc project'

# push 
git push
