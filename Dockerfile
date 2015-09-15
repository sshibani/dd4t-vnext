FROM jtbennett/aspnet

RUN sudo apt-get update && apt-get install -y git 

RUN mkdir dd4tweb

RUN git clone https://github.com/sshibani/dd4t-vnext.git /dd4tweb

WORKDIR dd4tweb/src/DD4T.WebApplication

RUN ["dnu", "restore"]

ENTRYPOINT ["dnx", "kestrel"]

