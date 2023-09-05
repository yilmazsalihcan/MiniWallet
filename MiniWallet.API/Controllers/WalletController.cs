using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniWallet.Application.Features.Wallet.Commands.CreateWallet;
using MiniWallet.Application.Features.Wallet.Commands.DepositWallet;
using MiniWallet.Application.Features.Wallet.Commands.WithdrawWallet;
using MiniWallet.Application.Features.Wallet.Queries.CurrentBalance;

namespace MiniWallet.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet([FromBody]CreateWalletCommand createWallet)
        {
            return CreatedAtAction(nameof(CreateWallet), await _mediator.Send(createWallet));
        }

        [HttpPut]
        public async Task<IActionResult> Deposit([FromBody]DepositWalletCommand depositWallet)
        {
            return Ok(await _mediator.Send(depositWallet));
        }

        [HttpPut]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawWalletCommand withdrawWallet)
        {
            return Ok(await _mediator.Send(withdrawWallet));
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentBalance([FromQuery]GetCurrentBalanceQuery currentBalanceQuery)
        {
            return Ok(await _mediator.Send(currentBalanceQuery));
        }

    }
}
