using System.Text;

namespace AdventOfCode2022
{
    public class Day3
    {
        /*
         * shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors) plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won)
         * */

        private void SolvePart1(string input, int result)
        {
            string[] eachCarry = input.Split("\r\n");

            int sum = 0;
            foreach (var item in eachCarry)
            {
                string strLeft = item.Substring(0, item.Length / 2);
                string strRight = item.Substring(item.Length / 2);
                var sameChar = strLeft.Intersect(strRight).ToArray();

                var xy = (int)Encoding.ASCII.GetBytes(sameChar)[0];
                if (xy < 97)
                    sum += (xy - 64 + 26);
                else
                    sum += (xy - 96);
//                sum += 0;

            }

            Xunit.Assert.Equal(result, sum);
        }

        private void SolvePart2(string input, int result)
        {
            string[] eachCarry = input.Split("\r\n");

            string intersectedRucksacks = String.Empty;
            int sum = 0;
            for (int i = 0; i < eachCarry.Length; i++)
            {
                switch (i%3)
                {
                    case 0: // kein Rest -> initialisieren
                        intersectedRucksacks = eachCarry[i];
                        break;
                    case 1:
                        intersectedRucksacks = new string(intersectedRucksacks.Intersect(eachCarry[i]).ToArray());
                        break;
                    case 2:
                        intersectedRucksacks = new string(intersectedRucksacks.Intersect(eachCarry[i]).ToArray());

                        var xy = (int)Encoding.ASCII.GetBytes(intersectedRucksacks)[0];
                        if (xy < 97)
                            sum += (xy - 64 + 26);
                        else
                            sum += (xy - 96);
                        break;
                    default:
                        break;
                }
            }

            Xunit.Assert.Equal(result, sum);
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1(introductionString, 157);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(introductionString, 70);
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(puzzleString, 8085);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(puzzleString, 2515);
        }

        string introductionString = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

        string puzzleString = @"fBDGBcBrGDvjPtPtPV
QhzJLlLJZgLZzNTgZClQHvRvHFvrjrvnNjHnFjPF
ChldsCZhsQzsCGrrSfMfGpfrdM
MJbgcgJlvMSbfjMSbllmCrntwmFrrFwgtCtFFG
vPhddVZZhmnmdnHmHn
vNBZppZQhjSzfScjDN
jwhqbZRvbzvbqqpqzqHHCCCzsLmmQVtmJVJtLWLPrVLLVrmp
dGMfMGMdBBMSTfdMGTNlcZGGPSmQJVVWsJQPLmPLVPtmWPLW
llMBBcfBnBcZMGgqvCDbjbwgCHjvzH
RSDprRrwgVVRwrGqrJsNFJslgglmmNszzN
LLnWjcHWnCTmpClhHp
MpfMZWjtLMjpjtBPnLPndMBGRqwbwBwvrGwGrGVbVvwD
PQNGshQWtwWNcjssJHHJdlBLBlLrRDFFCrdwSlLB
mbzqZqsgMzfnbmbfgpZvZBLrLlSCrprDlLCrdFBlDL
MfvZzqMmsVnVzzTTbMzfvnctjhcHPQJJjNTGWjQJJHWP
MdLWQdMZrPQWsPdMQPLSqGpHGbGqpqqqVzpm
BhgFhVgnlgBNFtNwzpbTGbTTHpwwbF
tCfvvCfgvBjnfflftCvjWZVddMQZsMMsRdMZMP
lTLdHVlqmqWdvjvJttvFlJtC
ngbMTgGhQpgrGtvCzcCJccCrcj
npgwnDpSDbgbbnGGDQnMDSMgZZWVqNTNPRRdwLLNLqmPZTLP
RRSFZvRdrdbSvSVLRZrSGZZrHcHPfPPwJJVJmPHmJfHVThPm
WnLjBQBCQWqCQwpPmHTcfQpm
gBDttlnqLqlvzzlGRRlr
wGpdGdddMPDWgFJGBzmMlntTbZMtZbnT
qNSqQrrqSjQVrsvTtzNnnZTnfNztZw
rcVrjjsswVvRRHsFJLCDCpCddGCCcG
jLMhCPWLCSWSrRLPWmPPLSCLtcTvHHDhZcfHHltlfZtlfgfH
rBBNrbVdtZlvVcZc
FppGdpFsnsqGJnsFzGdJszbdwSLRSRPrSRjqrMqCwQMWQqRS
jTjZwnpjMDfZnmZfsRhGGztqCzwsdGws
JHrWcNrNNrJHLHlzsCtzGRRRHv
rNLrVBJFLmfCnbTpVQ
LGWJvDFssFmMBhThMvnB
CprbCNZpwfpwfrbZJMQMTQcVVgBZcVQBZc
ptNwfwzHzqzlttbrlpCCqzwtFLGSWFsPDLWFHSDjJWSDLFDs
MZJjSsCsMsZSSdZJhdjZtCbPHljqlLPlPRRDLqHHqLbB
mmwmVpGrnngmggGwnccPbDBPLLLllLBcFRFb
GQzVTQTTVzVrQrmvpTnmrQmMvZRhZZCZSZfCsfttSJddNC
gHZZQRdVgRQWWRPHWPnttDTmqQqDQnStzNqD
bscfjslJJspBLsslNStSmTmLmmDTzNnS
JJCrbbhBsplrrChpBbfjlpbbFWWVggPPhZVRRFPdVMddPnMg
FtLfHNhFJCClJlst
jnDQqnDSDSRqwBwnjdFlZbsrTZdsJsGCbw
zDFSmjSDVqnRMHmphPhfWPgW
rSpRtSPWpStVqrwSSdrrhZvnBBnDBvsqjlBqvvnnzl
LFNLLFfFFhMFbcbmbHbHgTNcvZvBZMsvBnJBzsZvjJvZlvnZ
gmFLhTTbFmmQrrSWWpwWVtwQ
DzmDJGSccGJPcdcJPJqwplhjBHmHVwwtBthV
grMMvRsNRnWCFrgZRrZFhpVVlHVnhpVjVtljhhhf
FFZFZTsvCMSQTdGcTHzT
TLsGTnZncjVmVLgm
DvRwMcHMvMbwBVlCBlzlMjCC
FdRtRHDwQvPnTfPqcFPP
rZNdpBSldLLCJZbbCT
WQcQwqsmQmmqJgTRLRCqLq
znQcwsmPcmnCzQmfGGnzHSDFlNptNthPSdllhFPplS
vWCWvVhhjPNjNNvWVNbnbHnrbGrmlPqnqqbw
JdZSLMgsdgQMcQssQnnDqmDqlDqnDlwrHc
tdgQSSdpQtSMSNWpWRfRCwjpjV
qhdJFpChSJhDFDrqbpJbddSHPPRnGGBfBrHfZRnjRnlBZH
zsMVzmwmtLMtmQTzvwlRcZnZZljvvfGcBjcZ
ttQzMtVgMWVMQsmtJgqJgCJbqhgbBSBN
BWvdCmZBrNRrGSSfTzQJJRTz
gMblllMgLVswbgwMsLjgLLnlVtfHfttSQttTJTSQGfGPTPTB
LMgnMgscgqbFBqvBNFBmNm
VlcczDZjjVbznwLnwpTH
NfJPJNfJdJMSHSHnjBRSnbbL
NddqPttjsdZDqhcqlFcD
NVrNBBFFFrvJJrVTFTNvWBCbCCgWGqDqhqghCLqbqtCC
mfZVPZPcqtLbcqgc
fwZlwzfRfQQPMZBBwwBjFSjTVrBT
GWWNMfWWwGWMtjJnVnJzlzVsvLnsVn
ZpRqHTBddsvtPLqVPP
bpSDgStgTbdFTpDdRmfwfmfGFcMQGWMcjQ
gCgGBgfCbRLbBLGnGBBfRGwprctZFMvtFtvSNNTZZtMvLc
DhJhDzzQlDdshVJlDdhqzqzQZFpppFMNtMZMtFFVvtpSMpFV
qQdsDHWWslnNgHmBbHBf
MRvnJFZVnvzJrWWSqMSPTSNqNj
GlcbDpCHCCczdsDppcccBGccqjwTTwQPPSjNjWSWSwwsPsws
GbdlBbgdVtngtzVg
GqTSRpgJgDNSNJqJlSTJlJCBmmcnjCjLFcMFmnGsmBsM
HPhfPrWdfrQPPPhQWHbLFFWFCmFjMBFFsLBFwj
fdzVbvfshrbzvfbfdVPvQtqqJgqgDpNTgqZZtglZtZDD
wsPhrDMfrwdvHdTFrrtH
lnQbNBbqVBqHGJSddvTlJJJJ
cjnHznzbQmgzqQjBWwZwRjDRfWWhWsWD
SsScnttbbSzRRMMMLpsBLP
dDJGgjGJVMSBBBMj
JGDNCfgfSChDJrgqdgqJqGbNbbcbNtzWFctbzzlWtFFn
dtsBsCMtwSVBlLZZZnMgcMZZ
brppQHGznLZgJzJJ
fprvRpNHpNnvbGDBCBPwBWFWBFBvtB
qjgjSgHNlSGHnjfSVDvDPRDDtcdDcGtD
FMTnnLQZtRZDbcZv
zhBLzrCwnCsTCMCQTFLwwCzpHgNlNmHqhlqSpWllmlllhh
bJqqFdfbGdfPNsJsdSRCFLRHLDDBHDnShL
lQWlWQpwQjlpwrjrwTSCTLMCCNTHRDDDDRRB
wtWgQmQQWtwWwrljNPfGPzJmbbfzmzZf
MjppbDGmNNblCpzsNZzhNPgHtzzs
qvdrqrQVVWLfqWfRRPRwZPPwggpf
cqdcdpqSrrSvrvWvvvrSbcGTTTbGlFFCCcnnGbTb
HLNfNGttHVFBHWSr
RZCLsbCbLbLhwzDgbZCbRZhhnpSnnWpWplFFnDnqlBFVpSVB
MzbhhzwcLGGfGMvMTv
PdBlpdVJlmftGbTzwbtRTGGL
NQNMgWNNQNScDhsSHSWhsNgbRCLwGnnwqLwLHbbCGGTjTR
MvhRMMRvQshgSNDWFrfBfJFZrFPJJJPBBp
qdtnQqWtnjfGGzsnGQmWWfqQNbRTgggRFNbCFNSSFlSJsrTr
PZBBbPMvVcMpSRSlSCpCSgCT
MvHZhwMVLDHDcZMvLQfwGWqwWjqjGbmnQq
NFPmjNhGthGNpddddFpzBbqPczSqPDzzDgbgLZ
VJWvwQrlLHWrvlQZDgZSSDSDBqbb
WfHwMWfvRvMWrWJsrfMRWGFmGGLttMNpjCpTdmFFht
DppfNpLwhTBRDbblgWNgCdgCvs
nLcLqFJrHJmLcFmqMFCdzdHdsgvdzvbvWPWs
nVFqrrQcSVmFjrmJnrFrSjTtRGRLBwfRTfZwhBQhRGGw
sHrZdHGpHhsrLpsssGLzhrdtWdJTMWJvffVdmnbfJVnW
cggRDCCjlPQCgDRnfbTtfMJfWVTm
cCDwQNlwQPjgCFDljwpSLFzGFzZhzsstSpGz
dGTGpGdPZZCpnnLRpgzgzn
lflshFjFcrNdBjMjMnmL
hDfrldDfbVPbQCtHHZ
cSRZmtFZScfjZtLbmCNMqhMVQCjwqqCwVB
pddczHpHHzgWdGdsvPrPzcvrJMNwJCQwJhNwBhCJBVMpCVJB
cgrWcHdnPHHznlmftmtLnRDD
PZFMMVJVZmVJVHMNJNVfNdNNSnSWsSRhgRRQnWSsRnSWmszc
llljlTwlprClTbTpwLlgQqhcnwnczhcgSqsQRR
TpCtGtrTBDZVZHNQZQdB
SggjglBBlzbDgdpFJddZpF
CCNLsfNfrcMLsTLPfPmndmTwmZtZJZJdJplp
sfWCqcvMrlMfMLsLNfhVGvjjjSzSzVQhQvVH
NTBhNhfBvfflsbSmcl
nrMZRnHHwBMZRsSsgSsGrbmdms
nPPFVwVWJqJBVJLT
vvWqWJWJvzfFZZJvWQzqZvdPPHjSfHjssHsbsfbjSHRR
DCwtDVjMCrltCnCrDCDmbTssPHLTLldssdSldSRp
nMcGtDmBmMGrGvvvvFhjFZgWcN
tGWWWfWpMDjMZbTbnqTC
JFscJzFPDJDJZnrJ
sBFPcBsSPBvmSPwFzSSQfpwWfDpgNNfWtfgpftfg
BvTsJJzQJLMlbhmbFlNmTl
PjGnpdpGcgDmhvnvmvlbmq
dRtDGGgcDtjRcwdgQLVLRMJsszJVLRQv
FGbPPfFSchBGSvGGWsjSTLVQLLVTsQlj
dDzPnCrRCrrWHHTTHsdVjs
wrwCgzMrNprCwRJJwnnbFmmpGZtcvcbFfPFmFG
fbrJjmmmZgmZLJZsBBWlCBGnCWdnfF
RVMDDNDHPNvvRvDtHMcctMqFslqWPnClddlClFlnBqCG
MDDvHzHVQMMDtTHJLrnggSZLTJZgTL
dgBBCBBdvbmrRczFMHMSrqjjSPzn
tZTwQlLVwnQLQQFJVPzjDSSzJFPD
fhWhQpTTZQlWfQWpWQWQLhBgchhRCsdbvNnbgRsmRR
LttflLnGrnMsmmHgWTbdMW
vBSWzZRDccWBFBmJsmPJmgbsgB
FppcFWRNRZLLppGrGrqr
JJClRmLlFGvMTlFLLfPFQQcDpQcjFcjqBc
zgHSZhggggtwSZhrDgsZgbjVQcVcjPNqcpQQqBjNQzNp
hZnsShSWGDMMMRnv
RbDbslClhsfNCbsMjbNrjNMfpTTTTJSzHTpLVzLLVWVzJz
ggFGgmqFZBnnSzTWPpHBLzdT
vmWZWGwcZZqthjDrbclNCjlD
dCHwnVBBCBnVHddqnQRdbbbrgTsfWwjcWlsfwDDg
hhlFpMtGJlZmDjfWfscjWDGD
hFNFvZmppmSlNJMmNFztmzFhdVPPHQQqqHPvLBQnBQQPQPnC
WfzsplQpvQgfwzlbllPGtPJTTwtGGZBTTGJB
VrmMjmFDjNjjDFBhHTcZtBRRGcGV
mqrFmmLrjmjZnmqLrmQsfvbsfsSSlpWqgglp
lsQVfDpfflpGGmQRRgdQbdfbWdqnjnHnqZHJTqqrWjqqcWnZ
PPFhFFtwzqjHgjWTWF
SwMwMhNMlMsgfQfl
cSttSDQQCgVvQQSvsstthQcslLLgLgLnpglffjfFlLFblnlH
rTTwTbdBpTHJfZZJ
BddPBzwMBzqRqddRGbVShvVhVQvQscvGtV
sSpsHqHMspqMqWsspwsSWsbBPvjrFbddrGTvZLFjdZTZGLLG
NccDncRVNDVJLvLPPJTJGvJL
mRCDNNhgDnghNRQNggNRcNlMtpMPMMtHtShlSSMtlhHW
QrjSFQWzDdCHtpFlbBbVns
PhJwNLfNqgfdLlZHpZJJpptBBb
qmwhfhhfMNWSmSdQCddv
VfRMdbshRmJBqbmDBH
CWwWCWTCrzFpzWwCWFzgppqHDtZBfqDmQtBftBDFqBtq
WlzrWWGWPrpGCGdfSsRGVnGVdNnR
lhLTfppGRhhbZntsbTqMbq
jrHWBHrMgjHPWMgWBJWBWjstPvwFFbbbvtvFqbPtvqws
rBJJJVWjBjLphcMhSVRV
fjrBPBjWVPWPrwtjPpRQZZVdZQddFdHFTZdT
GqlllsGLgMCqGqgTFbmHdTmRzgTm
qHchGscqGClHGhNwhjJJNWpwPB
JzrrJZqLFrnMzVjNNnNnNDwdGHGlHlHbpTZDlmpTHb
gQfQcRWPWgQSStCtfcsPsPmhsGdDhdGDHTwHpDlHwhTG
fvWQgCtfWgtttcPQcPBtjVdBMJMLJBFJMJVzNrJr
cMzNjGGNQFVzNNQVjNdqRLbFDqRpgLRDpDHD
TwtwWJJBJSvmJCWSvTTmTbBpfpRZSfDqqSqDgHLgqdDDqD
vtvmPrtWQMrbhMrG
NqCPqJNJQQQQGCtGPmMTrTpHlNdmpTrwdN
bzhZRDbnZHrmmcwRfM
vWhsnVWWswhSFvDSDsnhbDsLPqqPFjQjgFgtjqqCLJPgQQ
nqpfqfcnclcNcjjQ
BLQJQmLPPvdtTFNjlFNwPs
DgDgLLCQBBmpVSMrgfqnpp
njCnCwwcVCBWjrrhWrHdzJqmhl
QNGptTTQGLTdhqmdJBHT
GtLvDDvLMvppGGVZMssfCBMfcfMf
npPQGpDnsbJhvldphHFfpl
mgqZcqzczzzcqmRzrbrzBvfBLvlhhftFWlhlFtLBvv
cgjmTgbbMgmzqRRwGDDVQVGVSPwTJV
VhPNvgVhbjPsNvsChTZlHtlwZccZMhwlcm
fpznDWDzDfRqffpnrmcRmwlTMZrHTBHB
fWdQLFSnDzpndqzzqgsVvPsJLMsPCgvjPP
RFRDQVvqVMZGBVzqgqPNJNmNhqqPjnPS
rcLLCWrtwlWrWlTbTtlLWrWtjPPgdwgjmNmShpJnjSpSjgSg
LbLTnbbTHsWlfbtZRZGQHHZZDQMVFz
dwcLLSLVdwLdvdfZNJgQZWfffVJQ
CTMlCRCCCTCtBmCFMQJNNNbNfWvQjvZggT
mRnnnpFlvhnlMmBmFMCMCcdHrwzqszprdcwzLDwrSz
JSHLHRMlzJHcGMpwCffZctZmgfqqZm
vnTWvQrnrQjNnBWvnvDnVgqtVWwVgfFmqWfqZFWZ
rdQDBdBrQQhmBNjDTmrTnzPzPPLHSSHzHHRHRLdGLl
GvMRRwGwRFmZRnmbMhZMGcpgZBpdgBJcTsjsBstdds
SNlPzzlPDDQSDDDqfllqDLBpTgWBgWdTpcWjJQsWjjTp
rScrCqPCSLDNrqlFmRVRRrbhmRmFRw
dbtgMNlNSMQPSLNdvVQgSfcHHfJfHJtfmmHTqZffJH
wssswnzwChsrGCCwGCjzCsHFHbzZffbFBcffbHHTBJTZ
rsDRGDwjhWbrbRhGCGLdLNlNQVVDPSlMVMvv
BgPccPPRlZZmTMTZzZTC
jjNjntVtQnWHrJjFPnnqDqJTJTzqJmDDCqChzS
FnQHQjHVNnWVvQpgLPGRdcLpbfLLBl
JLMhFJfHHLJChRvfjLJJnFRpPrpPSrNnrTrTTPntTptrpw
QgcBCqcGBBGzGrNQNSwSrPPTsr
zzWdmzcWcdHCJCRRCF
GSRcjdjGcBnFWbnVLFQR
pCNqTqhDsMsMmNtNCZmMMtdCbVFzbFwnFFnWWFnzVLTQWQLF
qNJpMdCsDNsNNvGPlSPPJjfBBB
lsHjgmFsnFTwHgSPDRSrDqnqrrnr
NmZWcZmzNMZWJbbWvJMJJMzBBBrRrdRfDfppBNqSrrrPBP
JZQZzQtWJhmltVwVCjwGjs
DslBHDpdDlslgffFWnGqHfzH
JNMMCCCCSMvzzGfMzP
hNtCJTwRwZQbwrplpDjlpz
vwvJwLBzwhhwvzwrgwshLwVWWgFfmlSFVRDfWFSVFVfF
mNqbdPnNdpdjnMqSFFMDfSFVMDFRSV
ddpTPTqmbNjjNqndZzvLzJZzHCrrCCzsJH
SLjjlGMVpLpNSTDspsrHpFFwRrZgRfwpfgFZ
nQtWPzbPNQtbdzPtbBCQJNPcwFvZJZFFJrwRwrHcfcfrgF
NQCnqPBWddbPnbCdWdWQnmdVhsMMDsslmSSmMLlVTTDVMm
FZmcqBChfFmfsDjjnNMNjSDgNs
RZwzdvdZRvTRRlvWSgDjStnpntDwNMtD
vHTGRvvvZHlQPRQTbPTVfLJPqcLJBhfmFVJPCF
dStFcccjFjqGFrFHmSHFBjBvzhpprWZpppbppDvzhsvDhT
VMVLNfCCCRTTDtDDDTRz
QLJwMMLnLNVLdtGGgmdScBnB
nTCWnTnrllglrNgNTZFgSZbddHtdHLLwtMLQtfbM
BJGqppPCJVmqqhBJCdwwpLSLHddfHSLHtw
qmzBhczVGsqVBqnFcCjRWNrNlrgD
phrHLNtnMpslNFfwVGwFZSBfFTTz
cmJJDmmbCnCCfBSJGVBwfBfz
DdqdDbcqCPcCQRWmQPqNHhnRMntNNMNhlsLsML
gHHWJWMWsHWgWSnPwVnVNGGDbnwwTl
QjThjhFqqhmQTCVPfDVqPbDVVl
mpFLLrZjjBcmLFmmFtLBJMddMgSdHTscvcJzRHRs
gRdwcCddwghzddzzzsGfZsGnqlqVVhjGDj
DMBNpMDHrNrNLFMmpQJHZGnPjFPFlZjlfGVljGVf
SpbQNmHMzgcRwSSD
drqcMpNbpFpmjzfz
HLGZGsnGLwllzHGGgGnGsBFfmJtmtjfJDSBSJJJB
ZZwQwHTgZnwLGTTnQTHVlgbWCQNhzNcMqbrzcNNQdNcr
TDScznfzNlpbbrtsvjdcbh
BBHqFGWGFmVWqVBBWMtvCLvsLdvrvjLjdLbsvm
tPZHGFJPJqVwMWHJVRRSZNfQnzfpnTpNfl
FWNZgWCngsNwJwlQlrRTRhSjSS
GGLcVVcVmppMmpTjTRHlbRbSrVBh
rvmdzPcdzmzMrCNNPJFntFsCtD
MtfLBzSLmMtfBMQzMmzmSlfdTDvGCZGCndZnZgWDwGCZ
HhqrrpppcqhdbjPvbgGvTCnWDbTWZT
cNjsdqPqchJBlmzlVQLtBJ
DwwVFZlDBsZFDvLPdpjLjSVHjpLc
nMnztWhhfPSffcddGpgp
tQnrQzhzNtzbNrBwPJwTslTvNFFP
LWMvHJJrJwtzvgwMwVdGfcpNfdDVDWfdBB
jZPFmjnbmhPfTVfVHdhTTV
qqQCmCmbqCQqjQsQvrQSHSJrzz
wNzmDRwmgcGphZcPvLLZHjjFLF
JlbsClVVqDqFZjJD
WSlnCbttftsCsWftbCCrTffbpdzMwgMgSpRmdwdRzggmDGGg
gCCRBClgfCgFFTltTGgBqTsQhzLzQQNPnvrNzHrrfPzHLr
DMjqWSVwDwDwZDHZNvLQnrnrPrNv
bcmWJqdVcbtgBglbGTCl
SFDcrFHtlqhqqLdzTTwdJLPNDL
vBWsWvsmgvvvdPwNnn
smfRbpsWMBmsmMsBBBNbtSFttjCHSScbhHtHhHjb
SQpgGgMNvggQGMvQcgnHWmldnHWTWndnSHHF
DwbDPzthtttljTzTFBlmzl
DstCswftDbZbCChPPRrfwsfPQlLccJQLvVGNGNVpMNvZcvgG
HdqfjjLfHqFSHddVWNBjsWhWRRJtBNBs
gPMQHpmrcmnbRQNRRJsWttWW
pmbcZwbrPPrnTPMFFdDwqHwvHDvzDq
FFsVtFGVGvWVhlfVhzlsFvHbPwPmwHLTSbLjcLtbSbLm
rZrpJwCqnnJHmqcbcTLTbS
RCZZQMQpzvRhswVg";
    }
}